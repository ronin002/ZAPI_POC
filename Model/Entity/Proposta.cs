using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ZurichAPI.Model.Entity
{
    public class Proposta
    {

        [Key]
        public Int64 Id { get; set; }
        
        public string NumCPF { get; set; }
    }
}
