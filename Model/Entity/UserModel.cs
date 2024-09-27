using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ZurichAPI.Model.Entity
{
    public class UserModel { 
    
        [Key]
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string? Last_Name { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public DateTime Creation_Date { get; set; }
        public DateTime? Updated_Date { get; set; }

    }
}
