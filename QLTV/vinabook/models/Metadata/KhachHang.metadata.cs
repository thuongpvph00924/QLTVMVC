using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using 2 thư viện thiết kế class metadata
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Vinabook.Models
{
    [MetadataTypeAttribute(typeof(KhachHangMetadata))]
    public partial class KhachHang
    {
        internal sealed class KhachHangMetadata
        {
            [Display(Name = "Mã khách hàng")]
            public int MaKH { get; set; }

            [Display(Name = "Mã thư viện")]
            //[StringLength(30, MinimumLength = 6)]

            //[Remote("CheckUserName", "NguoiDung", "Tên đăng nhập đã tồn tại")]
            [Required]

            public string TaiKhoan { get; set; }
            [Display(Name = "Họ tên")]
            [Required()]
            public string HoTen { get; set; }


            [Display(Name = "Ngày Sinh")]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            public DateTime NgaySinh { get; set; }


            [Display(Name = "Giới tính")]
            public string GioiTinh { get; set; }


            [Display(Name = "Điện thoại")]
            [Required()]
            public string DienThoai { get; set; }


           


            [Display(Name = "Đối tượng")]
          

            //[StringLength(255, MinimumLength = 8)]
            [Required()]
            public string MatKhau { get; set; }

            //[DataType(DataType.Password)]
            //[Display(Name = "Xác nhận mật khẩu")]
            //[Compare("MatKhau", ErrorMessage = "Mật khẩu không trùng khớp")]
            //public string XacNhanMatKhau { get; set; }


            [Display(Name = "Email")]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }


            [Display(Name = "Địa chỉ")]
            [Required()]
            public string DiaChi { get; set; }

        }
    }
}