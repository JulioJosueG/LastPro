using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NewsApiREST.Models
{
    [Table("State")]
    public partial class State
    {
        public State()
        {
            Articles = new HashSet<Article>();
            Authors = new HashSet<Author>();
            Categories = new HashSet<Category>();
            Countries = new HashSet<Country>();
            Sources = new HashSet<Source>();
        }

        [Key]
        [Column("idState")]
        public int IdState { get; set; }
        [StringLength(20)]
        public string StateName { get; set; }

        [InverseProperty(nameof(Article.IdStateNavigation))]
        public virtual ICollection<Article> Articles { get; set; }
        [InverseProperty(nameof(Author.IdStateNavigation))]
        public virtual ICollection<Author> Authors { get; set; }
        [InverseProperty(nameof(Category.IdStateNavigation))]
        public virtual ICollection<Category> Categories { get; set; }
        [InverseProperty(nameof(Country.IdStateNavigation))]
        public virtual ICollection<Country> Countries { get; set; }
        [InverseProperty(nameof(Source.IdStateNavigation))]
        public virtual ICollection<Source> Sources { get; set; }
    }
}
