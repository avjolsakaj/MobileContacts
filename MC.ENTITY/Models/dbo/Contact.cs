using MC.ENTITY.Models.Base;

namespace MC.ENTITY.Models.DBO
{
    public partial class Contact : BaseEntity
    {
        public int PersonId { get; set; }

        public int ContactTypeId { get; set; }

        public string Number { get; set; }

        public string Email { get; set; }

        public virtual ContactType ContactType { get; set; }

        public virtual Person Person { get; set; }
    }
}
