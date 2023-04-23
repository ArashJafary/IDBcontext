using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mime;
using testIDBcon.infrastructure.Repository;
using testIDBcon.Model;
using testIDBcon.Model.DTO;
using testIDBcon.Model.Repository;

namespace testIDBcon.Controller
{
    [ApiController]
    [Route("[controller]",Name =nameof(UserController))]
    public class UserController : ControllerBase
    {
        private readonly IRepoUsers _repouser;
        public UserController(IRepoUsers repouser)
        {
            _repouser = repouser;   
        }

        [HttpPost("[action]", Name = nameof(InsertUser))]
        public async Task<IActionResult> InsertUser([FromBody] UserE_I_DTO UserIn) 
            => Ok(await _repouser.InsertUser(UserIn));



        [HttpPatch("[action]", Name = nameof(UpDateUser))]
        public async Task<IActionResult> UpDateUser([FromBody] UserE_I_DTO InUser, [FromQuery] int Id)
            => Ok(await _repouser.UpDateUser(InUser, Id));



        [HttpDelete("[action]/{Id}", Name = nameof(DeleteUser))]
        public async Task<IActionResult> DeleteUser(int Id)
            => Ok(await _repouser.DeleteUser(Id));



        [HttpGet("[action]",Name = nameof(GetUsers))]
        public async Task<IActionResult> GetUsers() 
            =>Ok(await _repouser.GetUsers());




        [HttpGet("[action]/{Id}", Name = nameof(GetUser))]
        public async Task<IActionResult> GetUser(int Id)
            =>Ok( await _repouser.GetUser(Id));
    }
}
