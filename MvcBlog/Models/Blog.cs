using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcBlog.Models
{
    public class Blog
    {
        [Display(Name = "ID")]
        public int BlogId { get; set; }

        [Display(Name = "Tên")]
        public string Name { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Display(Name = "Chủ sở hữu")]
        public string Owner {  get; set; }
        public virtual List<Post> Posts { get; set; }
    }
}