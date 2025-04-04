using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tildaBlog.DataLayer.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Slug  { get; set; }
        public string Metatag { get; set; }
        public string Metadescription { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
