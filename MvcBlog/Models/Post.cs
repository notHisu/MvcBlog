using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcBlog.Models
{
    [MetadataType(typeof(PostMetadata))]
    public class Post
    {
    
        public int PostId { get; set; }

      
        public string Title { get; set; }

    
        public string Content { get; set; }
        public int BlogId { get; set; }

        public DateTime CreatedDate { get; set; }
        public virtual Blog Blog { get; set; }
    }
}