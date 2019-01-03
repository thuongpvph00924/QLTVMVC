namespace QLThuVien.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QLMuonTra")]
    public partial class QLMuonTra
    {
        [Key]
        public int MaMuonTra { get; set; }

        public int? MaKH { get; set; }

        public int? MaSach { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayMuon { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTra { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual Sach Sach { get; set; }
    }
}
