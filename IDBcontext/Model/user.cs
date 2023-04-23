namespace testIDBcon.Model
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = default!;
        public List<PhoneNumber> PhonNumbers { get; set; } = default!;
    }
}
