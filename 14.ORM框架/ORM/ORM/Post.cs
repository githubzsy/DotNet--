using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    [Table("POST")]
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Column("TITLE")]
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
    }
}
