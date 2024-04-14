using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcBlog.Models
{
    [MetadataType(typeof(BlogMetadata))]
    public class Blog
    {

        public int BlogId { get; set; }


        public string Name { get; set; }


        public string Description { get; set; }


        public string Owner { get; set; }

        public int Rank { get; set; }
        public virtual List<Post> Posts { get; set; }
    }
}