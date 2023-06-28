using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models
{
    [Table("AccountRoles")]
    public class AccountRoles
    {
        [Key, Column("id")]
        public int Id { get; set; }
        [Column("AccountId", TypeName = "char(8)")]
        public string AccountId { get; set; }
        [Column("Roleid")]
        public int Roleid { get; set; }
        // Cardinality
        [JsonIgnore]
        public Accounts? Accounts { get; set; }
        [JsonIgnore]
        public Roles? Roles { get; set; }
    }
}
