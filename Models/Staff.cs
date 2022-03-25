using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace webapi.Models
{
    [Table("staffs", Schema = "sales")]
    [Index(nameof(Email), Name = "UQ__staffs__AB6E6164FA764B5A", IsUnique = true)]
    public partial class Staff
    {
        public Staff()
        {
            InverseManager = new HashSet<Staff>();
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("staff_id")]
        public int StaffId { get; set; }
        [Required]
        [Column("first_name")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [Column("last_name")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [Column("email")]
        [StringLength(255)]
        public string Email { get; set; }
        [Column("phone")]
        [StringLength(25)]
        public string Phone { get; set; }
        [Column("active")]
        public byte Active { get; set; }
        [Column("store_id")]
        public int StoreId { get; set; }
        [Column("manager_id")]
        public int? ManagerId { get; set; }

        [ForeignKey(nameof(ManagerId))]
        [InverseProperty(nameof(Staff.InverseManager))]
        public virtual Staff Manager { get; set; }
        [ForeignKey(nameof(StoreId))]
        [InverseProperty("staff")]
        public virtual Store Store { get; set; }
        [InverseProperty(nameof(Staff.Manager))]
        public virtual ICollection<Staff> InverseManager { get; set; }
        [InverseProperty(nameof(Order.Staff))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
