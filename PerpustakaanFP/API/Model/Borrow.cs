using API.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Model
{
    [Table("Borrow")]
    public class Borrow
    {
        [Key, Column("id")]
        public int Id { get; set; }
        [Column(name: "MemberId", TypeName = "char(8)")]
        public string? B_MemberId { get; set; }
        [Column(name: "BookId", TypeName = "char(8)")]
        public string? B_BookId { get; set; }
        [Column(name: "BorrowDate", TypeName = "datetime")]
        public DateTime? BorrowDate { get; set; }
        [Column(name:"Returndate", TypeName = "datetime")]
        public DateTime? ReturnDate { get; set; }
        //cardinality
        [JsonIgnore]
        public Book? Book { get; set; }
        [JsonIgnore]
        public Member? Member { get; set; }
    }
}
