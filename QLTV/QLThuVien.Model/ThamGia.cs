namespace QLThuVien.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThamGia")]
    public partial class ThamGia
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSach { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaTacGia { get; set; }

        [StringLength(50)]
        public string VaiTro { get; set; }

        [StringLength(50)]
        public string ViTri { get; set; }

        public virtual Sach Sach { get; set; }

        public virtual TacGia TacGia { get; set; }
    }
}
