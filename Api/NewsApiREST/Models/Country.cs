using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NewsApiREST.Models
{
    public partial class Country
    {
        public Country()
        {
            Articles = new HashSet<Article>();
            Authors = new HashSet<Author>();
        }

        [Key]
        [Column("code")]
        [StringLength(2)]
        public string Code { get; set; }
        [Column("countryName")]
        [StringLength(20)]
        public string CountryName { get; set; }
        [Column("idState")]
        public int? IdState { get; set; }

        [ForeignKey(nameof(IdState))]
        [InverseProperty(nameof(State.Countries))]
        public virtual State IdStateNavigation { get; set; }
        [InverseProperty(nameof(Article.CountryCodeNavigation))]
        public virtual ICollection<Article> Articles { get; set; }
        [InverseProperty(nameof(Author.IdCountryNavigation))]
        public virtual ICollection<Author> Authors { get; set; }
    }
}
