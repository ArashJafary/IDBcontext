using Microsoft.AspNetCore.Mvc;
using System.Data;
using testIDBcon.infrastructure;
using testIDBcon.Model;
using testIDBcon.Model.DTO;
using testIDBcon.Model.Repository;

namespace testIDBcon.Controllers
{

    [ApiController]
    [Route("[controller]",Name=nameof(TestController))]
    public class TestController : ControllerBase
    {
        private readonly DapperContext _context;
        public TestController(DapperContext context)
        {
            _context = context;
        }
        //[HttpGet("[action]",Name=nameof(TestExtension))]
        //public  ValueTask<IActionResult> TestExtension()
        //{
        //    using (IDbConnection Connection = _context.Create())
        //    {
        //        var Data = Connection.Exqut<User>("select * from USER_1 ");
        //        var r=Data.ToString();
        //    }
        //    return Ok();
        //}


        [HttpGet("[action]",Name=nameof(TestExtension))]
        public  IActionResult TestExtension()
        {
            using (IDbConnection Connection = _context.Create())
            {
                var Data = Connection.Exqut<User>("select * from USER_1 ");
                return Ok(Data);
            }
        }
    }
}
