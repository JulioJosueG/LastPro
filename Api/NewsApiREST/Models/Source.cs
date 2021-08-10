using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NewsApiREST.Models
{
    public partial class Source
    {
        public Source()
        {
            Articles = new HashSet<Article>();
        }

        [Key]
        [Column("idSource")]
        public int IdSource { get; set; }
        [StringLength(20)]
        public string SourceName { get; set; }
        [Column("idState")]
        public int? IdState { get; set; }

        [ForeignKey(nameof(IdState))]
        [InverseProperty(nameof(State.Sources))]
        public virtual State IdStateNavigation { get; set; }
        [InverseProperty(nameof(Article.IdSourceNavigation))]
        public virtual ICollection<Article> Articles { get; set; }
    }
}
