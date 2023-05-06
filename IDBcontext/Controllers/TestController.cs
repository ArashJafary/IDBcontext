using Microsoft.AspNetCore.Mvc;
using System.Data;
using testIDBcon.infrastructure;
using testIDBcon.Model;
using testIDBcon.Model.DTO;
using Newtonsoft.Json;
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
                var Data = Connection.Exqut<UserGetDTO>("select * from USER_1 where Id=@input1",2);
                var Data2 = Data.Select(a=>
                new User(){
                    Id=a.Id,
                    UserName=a.UserName,
                    PhonNumbers= JsonConvert.DeserializeObject<List<PhoneNumber>>(a.PhonNumbers)
                }
                );
                return Ok(Data2);
            }
        }


      [HttpGet("[action]",Name=nameof(TestExtension2))]
        public  IActionResult TestExtension2()
        {
            using (IDbConnection Connection = _context.Create())
            {
                var Data = Connection.ExqutSingelOrDefault<UserGetDTO>("select * from USER_1 Where Id=@input1",2);
                var Data2 =
                new User(){
                    Id=Data.Id,
                    UserName=Data.UserName,
                    PhonNumbers= JsonConvert.DeserializeObject<List<PhoneNumber>>(Data.PhonNumbers)
                };
                return Ok(Data2);
            }
        }
    }
}
