using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tildaBlog.DataLayer.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        //whose write it we should prepare the UserId From User
        public int UserId { get; set; }
        public int CategoryId { get; set; }


        [Required]
        public string Title { get; set; }
        [Required]
        public string Slug { get; set; }
        [Required]
        public string Description { get; set; }
        public int Visit { get; set; }


        ////we should prepare a foreignkey for UserId
        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        /// each post HasMany Comments
        public ICollection<PostComment> PostComments { get; set; }


    }
}
