using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleContent { get; set; }
        public List<int> Categories { get; set; }
    }
}
