using testIDBcon.Model.DTO;

namespace testIDBcon.Model.Repository
{
    public interface IRepoUsers
    {
        public ValueTask<int> InsertUser(UserE_I_DTO user);
        public ValueTask<User> GetUser(int Id);
        public ValueTask<IEnumerable<User>> GetUsers();
        public ValueTask<int> UpDateUser(UserE_I_DTO InUser, int Id);
        public ValueTask<int> DeleteUser(int Id);
    }
}
