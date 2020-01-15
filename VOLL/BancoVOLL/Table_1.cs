namespace VOLL.BancoVOLL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Table_1
    {
        public int id { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string description { get; set; }
    }
}
