using Dapper;
using Microsoft.AspNetCore.SignalR.Protocol;
using System.Security.AccessControl;
using Newtonsoft.Json;
using testIDBcon.Model;
using testIDBcon.Model.DTO;
using testIDBcon.Model.Repository;
using System.Numerics;

namespace testIDBcon.infrastructure.Repository
{
    public class UserRepository : IRepoUsers
    {
        private readonly DapperContext _dapperContext;
        public UserRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
    
        public async ValueTask<User> GetUser(int Id)
        {
            using(var Connecttion =  _dapperContext.Create())
            {
                 var UserData = await Connecttion.QueryFirstOrDefaultAsync<UserGetDTO>(@"
                 select * from USER_1 
                 where USER_1.Id = @Id", new { Id });
                    return new User
                    {
                        Id = UserData.Id,
                        UserName = UserData.UserName,
                        PhonNumbers = JsonConvert.DeserializeObject<List<PhoneNumber>>(UserData.PhonNumbers)
                    };

            }
        }




        async ValueTask<IEnumerable<User>> IRepoUsers.GetUsers()
        {
            using (var Connecttion = _dapperContext.Create())
            {
                var UsersData1 = await Connecttion.QueryAsync<UserGetDTO>(@"select *from USER_1");

                var UsersData2 = UsersData1
                        .Select(o =>
            new User
            {
                Id = o.Id,
                UserName = o.UserName,
                PhonNumbers = JsonConvert.DeserializeObject<List<PhoneNumber>>(o.PhonNumbers)

            });
                return UsersData2;
            }

        }






        public async ValueTask<int> InsertUser(UserE_I_DTO user)
        {

            UserInsertDTO userDTO = new UserInsertDTO();
            userDTO.UserName = user.UserName;
            userDTO.PhonNumbers = JsonConvert.SerializeObject(user.PhonNumbers).ToString();
            using (var Connection = _dapperContext.Create())
            {
                var Row = await Connection.ExecuteAsync(@"INSERT INTO [dbo].[USER_1]
           ([UserName]
           ,[PhonNumbers])
            VALUES
           (@UserName
           ,@PhonNumbers)", userDTO);
                return Row;
            }
        }






        public async ValueTask<int> UpDateUser(UserE_I_DTO InUser, int Id)
        {
            using (var Connection = _dapperContext.Create())
            {
                var UserResult = this.GetUser(Id);
                if (UserResult == null)
                    throw new ArgumentException(nameof(UpDateUser));

                UserGetDTO User = new UserGetDTO()
                {
                    Id = Id,
                    UserName = InUser.UserName,
                    PhonNumbers = JsonConvert.SerializeObject(InUser.PhonNumbers).ToString()
                };
            string Query = @"UPDATE [dbo].[USER_1]
               SET [UserName] = @UserName
              ,[PhonNumbers] = @PhonNumbers
               WHERE USER_1.Id=@id";
            return await Connection.ExecuteAsync(Query,User);
            }
        }





        public async ValueTask<int> DeleteUser(int Id)
        {
            using (var Connection = _dapperContext.Create())
            {
                var UserResult = this.GetUser(Id);
                if (UserResult == null)
                    throw new ArgumentException(nameof(UserResult));

                string Query = "DELETE FROM [dbo].[USER_1] WHERE USER_1.Id=@Id";
                return await Connection.ExecuteAsync(Query, new {Id});
            }
        }
    }
}
