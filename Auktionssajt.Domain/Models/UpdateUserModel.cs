namespace Auktionssajt.Domain.Models
{
    public class UpdateUserModel
    {
        public int UserID { get; set; }
        public string UserPsw { get; set; } = string.Empty;
    }
}