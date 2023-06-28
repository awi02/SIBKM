using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models;
[Table("Roles")]
public class Roles
{
    [Key, Column("id")]
    public int Id { get; set; }
    [Column("name", TypeName = "varchar(50)")]
    public string Name { get; set; }
    // Cardinality
    [JsonIgnore]
    public ICollection<AccountRoles>? AccountRoles { get; set; }
}
