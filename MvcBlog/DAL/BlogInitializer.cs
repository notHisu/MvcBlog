using MvcBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcBlog.DAL
{
    public class BlogInitializer : System.Data.Entity.DropCreateDatabaseAlways<BloggingContext>
    {
        protected override void Seed(BloggingContext context)
        {
            var blogs = new List<Blog>
            {
                new Blog{BlogId=1,Name="Văn hóa", Description="Thông tin văn hóa", Owner="Văn hóa", Rank= 85},
                new Blog{BlogId=2,Name="Xã hội", Description="Thông tin xã hội", Owner="Xã hội", Rank= 70},
                new Blog{BlogId = 3, Name = "Tự nhiên", Description = "Thông tin tự nhiên", Owner = "Tự nhiên", Rank=69},
                new Blog{BlogId = 4, Name = "Kinh tế", Description = "Thông tin kinh tế", Owner = "Kinh tế", Rank=54}
            };

            blogs.ForEach(b => context.Blogs.Add(b));
            context.SaveChanges();

            var posts = new List<Post>
            {
                new Post{PostId=1,Title="Bóng đá Việt Nam thay huấn luyện viên",Content="Ông Nguyễn Hữu Thắng trở thành tân huấn luyện viên tuyển Việt Nam",BlogId=1,CreatedDate=DateTime.Now},
                new Post{PostId=2,Title="Tiêm phòng vắc xin bệnh dại",Content="Tiêm phòng ngày 25/02/2012",BlogId=2,CreatedDate = DateTime.Now},
                new Post{PostId=3,Title="Tin tự nhiên",Content="Tin tự nhiên",BlogId=2, CreatedDate = DateTime.Now},
                new Post{PostId=4,Title="ABCDE",Content="DEFQWEWQQWFQWF",BlogId=4, CreatedDate = DateTime.Now},
                new Post{PostId=5,Title="JKLUIO",Content="MNOASDFQGQWGQWGQW",BlogId=3 , CreatedDate = DateTime.Now}
            };

            posts.ForEach(p => context.Posts.Add(p));
            context.SaveChanges();
        }
    }
}