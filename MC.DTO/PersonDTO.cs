using System.Collections.Generic;

namespace MC.DTO
{
    public class PersonDTO : IBaseDTO
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? MiddleName { get; set; }

        public List<ContactDTO?>? Contact { get; set; }
    }
}
