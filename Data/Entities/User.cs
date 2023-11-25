using System.ComponentModel.DataAnnotations;

namespace ASP.Data.Entities
{
    public class User
    {
        [Key]
        public Guid UserID          { get; set; }
        public string Login         { get; set; } = null!;
        public string? Name         { get; set; }
        public string? Email        { get; set; } = null!;
        public string PasswordSalt  { get; set; } = null!;
        public string PasswordDk    { get; set; } = null!;
        public string? Avatar       { get; set; } //firstname/URL
        public DateTime RegisterDt  { get; set; }
        public DateTime DeleteDt    { get; set; }
    }
}
    
