using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NewsApiREST.Models
{
    [Table("authors")]
    public partial class Author
    {
        public Author()
        {
            Articles = new HashSet<Article>();
        }

        [Key]
        [Column("idAuthor")]
        public int IdAuthor { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
        [StringLength(20)]
        public string LastName { get; set; }
        [Column("idCountry")]
        [StringLength(2)]
        public string IdCountry { get; set; }
        [Column("idState")]
        public int? IdState { get; set; }

        [ForeignKey(nameof(IdCountry))]
        [InverseProperty(nameof(Country.Authors))]
        public virtual Country IdCountryNavigation { get; set; }
        [ForeignKey(nameof(IdState))]
        [InverseProperty(nameof(State.Authors))]
        public virtual State IdStateNavigation { get; set; }
        [InverseProperty(nameof(Article.IdAuthorNavigation))]
        public virtual ICollection<Article> Articles { get; set; }
    }
}
