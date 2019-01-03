namespace QLThuVien.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sach")]
    public partial class Sach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sach()
        {
            QLMuonTras = new HashSet<QLMuonTra>();
            ThamGias = new HashSet<ThamGia>();
        }

        [Key]
        public int MaSach { get; set; }

        [StringLength(100)]
        public string TenSach { get; set; }

        public decimal? GiaBan { get; set; }

        public string MoTa { get; set; }

        public DateTime? NgayCapNhat { get; set; }

        public string AnhBia { get; set; }

        public int? SoLuongTon { get; set; }

        public int? MaChuDe { get; set; }

        public int? MaNXB { get; set; }

        public int? Moi { get; set; }

        [StringLength(50)]
        public string KeSach { get; set; }

        public virtual ChuDe ChuDe { get; set; }

        public virtual NhaXuatBan NhaXuatBan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QLMuonTra> QLMuonTras { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThamGia> ThamGias { get; set; }
    }
}
