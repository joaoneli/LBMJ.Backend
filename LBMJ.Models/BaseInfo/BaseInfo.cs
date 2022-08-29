using System.ComponentModel.DataAnnotations;

namespace LBMJ.Models.BaseInfo
{
    public class BaseInfo
    {
        [Key]
        public int Id { get; set; }
        public int? CreatorUser { get; set; }
        public int? UpdateUser { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
