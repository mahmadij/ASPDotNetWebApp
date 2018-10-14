using System.ComponentModel.DataAnnotations.Schema;

namespace ASPDotNetWebApplication.Models
{
    public class Feature
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public Item Item { get; set; }
    }
}