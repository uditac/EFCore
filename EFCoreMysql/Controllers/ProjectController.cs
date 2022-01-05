using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreMysql.Services.Commands;
using EFCoreMysql.Models.Response;
using System.ComponentModel.DataAnnotations;
using EFCoreMysql.Models.Request;

namespace EFCoreMysql.Controllers
{

    [Route("api/project")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ICreateProjectCommand _createProjectCommand;
        public ProjectController(ICreateProjectCommand createProjectCommand)
        {
            _createProjectCommand = createProjectCommand;
        }

        [HttpPost("create")]
        public async Task<ActionResult<ProjectViewModel>> CreateProject([FromBody][Required] CreateProjectRequest request) =>
            await _createProjectCommand.CreateProjectAsync(request);
    }
}
