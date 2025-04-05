using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tildaBlog.DataLayer.Entities
{
    public class Post: BaseEntity
    {

        //whose write it we should prepare the UserId From User
        public int UserId { get; set; }
        public int CategoryId { get; set; }


        public required string Title { get; set; }
        public required string Slug { get; set; }
        public required string Description { get; set; }
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
