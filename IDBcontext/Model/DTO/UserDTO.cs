namespace testIDBcon.Model.DTO
{
    public class UserGetDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }= default!;
        public string PhonNumbers { get; set; } = default!;
    }



    public class UserInsertDTO
    {
        public string UserName { get; set; } = default!;
        public string PhonNumbers { get; set; } = default!;
    }
    public class UserE_I_DTO
    {
        public string UserName { get; set; } = default!;
        public List<PhoneNumber> PhonNumbers { get; set; } = default!;
    }
}
