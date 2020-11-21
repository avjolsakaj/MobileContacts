using MC.ENTITY.Models.Base;
using System.Collections.Generic;

namespace MC.ENTITY.Models.DBO
{
    public partial class Person : BaseEntity
    {
        public Person()
        {
            Contact = new HashSet<Contact>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public virtual ICollection<Contact> Contact { get; set; }
    }
}
