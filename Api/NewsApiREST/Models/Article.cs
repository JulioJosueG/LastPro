using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NewsApiREST.Models
{
    public partial class Article
    {
        [Key]
        public int ArticleId { get; set; }
        [Column("idAuthor")]
        public int? IdAuthor { get; set; }
        [StringLength(20)]
        public string Title { get; set; }
        [Column("content")]
        public string Content { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PublishedAt { get; set; }
        [Column("imageAt")]
        public string ImageAt { get; set; }
        [StringLength(2)]
        public string CountryCode { get; set; }
        public int? CategoryId { get; set; }
        public int? IdSource { get; set; }
        [Column("idState")]
        public int? IdState { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("Articles")]
        public virtual Category Category { get; set; }
        [ForeignKey(nameof(CountryCode))]
        [InverseProperty(nameof(Country.Articles))]
        public virtual Country CountryCodeNavigation { get; set; }
        [ForeignKey(nameof(IdAuthor))]
        [InverseProperty(nameof(Author.Articles))]
        public virtual Author IdAuthorNavigation { get; set; }
        [ForeignKey(nameof(IdSource))]
        [InverseProperty(nameof(Source.Articles))]
        public virtual Source IdSourceNavigation { get; set; }
        [ForeignKey(nameof(IdState))]
        [InverseProperty(nameof(State.Articles))]
        public virtual State IdStateNavigation { get; set; }
    }
}
