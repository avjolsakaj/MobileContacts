namespace MC.DTO
{
    public class ContactDTO : IBaseDTO
    {
        public int Id { get; set; }

        public string? ContactType { get; set; }

        public string? Number { get; set; }

        public string? Email { get; set; }
    }
}
