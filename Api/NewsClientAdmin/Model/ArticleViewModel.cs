using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsClientAdmin.Model
{
    public class ArticleViewModel
    {
        public int ArticleId { get; set; }
        public int idAuthor { get; set; }
        public string Title { get; set; }
        public string content { get; set; }
        public DateTime PublishedAt { get; set; }
        public string imageAt { get; set; }
        public string CountryCode { get; set; }
        public int CategoryId { get; set; }
        public int IdSource { get; set; }
        public int idState { get; set; }

        

    }
}
