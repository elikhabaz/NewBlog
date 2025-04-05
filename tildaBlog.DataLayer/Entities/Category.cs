using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tildaBlog.DataLayer.Entities
{
    public class Category: BaseEntity
    {
       
        public required string Title { get; set; }
        public required string Slug  { get; set; }
        public string Metatag { get; set; }
        public string Metadescription { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
