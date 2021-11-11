using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CMS.Models
{
    public partial class ArticleModel : DbContext
    {
        public ArticleModel()
            : base("name=ArticleModel")
        {
        }

        public virtual DbSet<Articles> Articles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
