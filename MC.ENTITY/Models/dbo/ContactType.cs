using MC.ENTITY.Models.Base;
using System.Collections.Generic;

namespace MC.ENTITY.Models.DBO
{
    public partial class ContactType : BaseEntity
    {
        public ContactType()
        {
            Contact = new HashSet<Contact>();
        }

        public string Code { get; set; }

        public string Value { get; set; }

        public virtual ICollection<Contact> Contact { get; set; }
    }
}
