using Dapper.Contrib.Extensions;

namespace LBMJ.Models
{
    [Table("Usuario")]
    public class UserInfo : BaseInfo.BaseInfo
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        [Write(false)] public string NewPassword { get; set; }
        [Write(false)] public string AccessToken { get; set; }
    }
}
