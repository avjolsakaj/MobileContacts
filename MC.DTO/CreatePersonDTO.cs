using System.Collections.Generic;

namespace MC.DTO
{
    public class CreatePersonDTO
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? MiddleName { get; set; }

        public List<CreateContactDTO>? Contacts { get; set; }
    }
}
