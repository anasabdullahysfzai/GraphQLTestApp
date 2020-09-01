using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLTestApp.Controllers
{
    [ApiController]
    [Route("/graphql")]
    public class GraphQLController : ControllerBase
    {
        private readonly ISchema _schema;
        private readonly IDocumentExecuter _executer;

        public GraphQLController(ISchema schema, IDocumentExecuter executer)
        {
            this._schema = schema;
            this._executer = executer;
        }

        [HttpPost]
        [Route("post")]
        public async Task<IActionResult> Post([FromBody]
        GraphQLQueryDTO query)
        {
            var result = await _executer.ExecuteAsync(_ =>
            {
                _.Schema = _schema;
                _.Query = query.Query;
                _.Inputs = query.Variables?.ToInputs();

            });
            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }
            return Ok(result.Data);
        }
    }
}
