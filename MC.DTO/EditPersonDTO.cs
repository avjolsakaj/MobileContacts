using System.Collections.Generic;

namespace MC.DTO
{
    public class EditPersonDTO : IBaseDTO
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? MiddleName { get; set; }
    }
}
