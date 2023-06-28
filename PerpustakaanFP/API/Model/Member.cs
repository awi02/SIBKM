using API.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models;

[Table("Member")]
public class Member
{
    [Key, Column("Id", TypeName = "char(8)")]
    public string Id { get; set; }
    [Column("FirstName", TypeName = "varchar(50)")]
    public string FirstName { get; set; }
    [Column("LastName", TypeName = "varchar(50)")]
    public string? LastName { get; set; }
    [Column("PhoneNumber", TypeName = "varchar(50)")]
    public string PhoneNumber { get; set; }
    [Column(name: "Address", TypeName = "varchar(255)")]
    public string Address { get; set; }
    [Column("Email", TypeName = "varchar(50)")]
    public string Email { get; set; }

    // Cardinality
    [JsonIgnore]
    public ICollection<Borrow>? Borrow { get; set; }
    [JsonIgnore]
    public Accounts? Accounts { get; set; }
}