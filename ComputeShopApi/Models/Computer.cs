using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text.Json.Serialization;

namespace ComputeShopApi.Models
{
    public class Computer
    {
        [Key]
        [MaxLength(36)]
        public Guid Id { get; set; }
        [Column(TypeName = "varchar(37)")]
        public string brand { get; set; }
        public string Brand { get; internal set; }
        [Column(TypeName = "varchar(30)")]
        public string type { get; set; }
        public string Type { get; internal set; }
        [Column(TypeName = "float")]
        public double Display { get; set; }

        [Column(TypeName = "int(7)")]
        public int Memory { get; set; }
        
        public DateTime CreatedTime { get; set; }

        [JsonIgnore]
        public Osystem os { get; set; }
        public Guid OsId { get; internal set; }
    }
}
