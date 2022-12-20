
namespace Domain.Common
{
    public class BaseModel
    {
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsModified { get; set; }        
    }
}
