using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using API.Model;

namespace API.Models;
[Table("Accounts")]
public class Accounts
{
    [JsonIgnore]
    [Key, Column("memberId", TypeName = "char(8)")]
    public string memberId { get; set; }
    [Column("password", TypeName = "varchar(255)")]
    public string password { get; set; }
    // Cardinality
    [JsonIgnore]
    public Member? Member { get; set; }
    [JsonIgnore]
    public ICollection<AccountRoles>? AccountRoles { get; set; }

}