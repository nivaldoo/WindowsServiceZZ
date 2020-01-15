namespace BancoService.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Titulo")]
    public partial class Titulo
    {
        public int id { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string description { get; set; }
    }
}
