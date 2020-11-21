namespace MC.DTO
{
    public class EditContactDTO : IBaseDTO
    {
        public int Id { get; set; }

        public int ContactTypeId { get; set; }

        public string? Number { get; set; }

        public string? Email { get; set; }
    }
}
