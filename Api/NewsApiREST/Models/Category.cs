using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NewsApiREST.Models
{
    public partial class Category
    {
        public Category()
        {
            Articles = new HashSet<Article>();
        }

        [Key]
        [Column("idCategory")]
        public int IdCategory { get; set; }
        [StringLength(20)]
        public string CategoryName { get; set; }
        [Column("idState")]
        public int? IdState { get; set; }

        [ForeignKey(nameof(IdState))]
        [InverseProperty(nameof(State.Categories))]
        public virtual State IdStateNavigation { get; set; }
        [InverseProperty(nameof(Article.Category))]
        public virtual ICollection<Article> Articles { get; set; }
    }
}
