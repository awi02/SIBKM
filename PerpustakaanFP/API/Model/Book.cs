using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Model
{
    [Table("Book")]
    public class Book
    {
        [Key, Column(name: "Id")]
        public int Id { get; set; }
        [Column(name: "BookTitle", TypeName = "varchar(255)")]
        public String BookTitle { get; set; }
        [Column(name: "Author", TypeName = "varchar(50)")]
        public String Author { get; set; }
        [Column(name: "Type", TypeName = "varchar(50)")]
        public string Type { get; set; }
        [Column(name: "Publisher", TypeName = "varchar(255)")]
        public string Publisher { get; set; }
        [Column(name: "PublicationYear", TypeName = "varchar(4)")]
        public string PublicationYear { get; set; }

        //cardinality
        [JsonIgnore]
        public Borrow Borrow { get; set; }
    }
}
