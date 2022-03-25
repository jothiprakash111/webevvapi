using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace webapi.Models
{
    [Table("Discount", Schema = "sales")]
    public partial class Discount
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("Discount")]
        public double? Discount1 { get; set; }
    }
}
