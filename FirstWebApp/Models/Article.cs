using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.Models {
    public class Article {
        private int articleId;

        public int ArticleId {
            get { return this.articleId; }
            set { if (value >= 0)
                {
                    this.articleId = value;
                } }

        }
        public string Articlename { get; set; }
        public string Brand { get; set; }

        public DateTime ReleaseDate { get; set; }

    }
}
