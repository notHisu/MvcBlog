using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcBlog.Models
{
    public class BlogMetadata
    {
        [Display(Name = "ID")]
        public int BlogId { get; set; }

        [Display(Name = "Tên")]
        public string Name { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Display(Name = "Chủ sở hữu")]
        public string Owner { get; set; }
        public virtual List<Post> Posts { get; set; }
    }

    public class PostMetadata
    {
        [Display(Name = "ID")]
        public int PostId { get; set; }

        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        [Display(Name = "Nội dung")]
        public string Content { get; set; }

        [Display(Name = "BlogID")]
        public int BlogId { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime CreatedDate { get; set; }
        public virtual Blog Blog { get; set; }
    }
}