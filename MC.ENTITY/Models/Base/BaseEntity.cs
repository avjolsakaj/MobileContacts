namespace MC.ENTITY.Models.Base
{
    public class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }

        public bool IsActive { get; set; }

        public bool Deleted { get; set; }
    }
}
