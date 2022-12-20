
namespace Domain.Common
{
    public class AuditableBaseEntity
    {       
        public DateTime? Created { get; set; }
        public DateTime? LastModified { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsModified { get; set; }        
    }
}
