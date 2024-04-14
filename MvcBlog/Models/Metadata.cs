using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcBlog.Models
{
    public class BlogMetadata
    {
        [Required]
        [Display(Name = "ID")]
        public int BlogId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tên")]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Chủ sở hữu")]
        public string Owner { get; set; }

        [Required]
        [Range(0,100)]
        public int Rank { get; set; }
    }

    public class PostMetadata
    {
        [Required]
        [Display(Name = "ID")]
        public int PostId { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 5)]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        [Required]
        [StringLength(500 ,MinimumLength = 10)]
        [Display(Name = "Nội dung")]
        public string Content { get; set; }

        [Required]
        [Display(Name = "BlogID")]
        public int BlogId { get; set; }

        [Required]
        [Display(Name = "Ngày tạo")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")]
        public DateTime CreatedDate { get; set; }
    }
}