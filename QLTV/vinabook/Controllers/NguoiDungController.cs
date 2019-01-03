using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vinabook.Models;
using System.Web.Security;
using System.Data.Entity;

namespace Vinabook.Controllers
{
    public class NguoiDungController : Controller
    {
        // GET: NguoiDung
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }

        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
        [HttpPost]
        public ActionResult Login(FormCollection f)
        {
            string sTaiKhoan = f["username"].ToString();
            string sMatKhau = f.Get("password").ToString();
            string urlString = f.Get("urlString").ToString();
            var usr = (from u in db.KhachHangs
                       where u.TaiKhoan == sTaiKhoan && u.MatKhau == sMatKhau
                       select u).FirstOrDefault();
            //TempData["UserName"] = usr.TaiKhoan;
            if (usr != null)
            {
                //create seession/ token for loged in user
               // FormsAuthentication.SetAuthCookie(usr.TaiKhoan, false);
                Session["TaiKhoan"] = usr;
                //lay gio hang cua khach hang 
                if (urlString.Trim() != "")
                {
                    string[] url = urlString.Split('/');
                    if (url[url.Length-1] == "Login")
                        return RedirectToAction("Index", "Home");
                    else
                        return Redirect(urlString);
                }
                else
                return RedirectToAction("Index", "Home");
            }
            
            TempData["Message"] = "Username or password is wrong";
            ViewBag.ThongBao = "Tên tài khoản hoặc mật khẩu không đúng!";

            return View();
            //KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.TaiKhoan == sTaiKhoan && n.MatKhau == sMatKhau);
            //if (kh != null)
            //{
            //    //<script type="text/javascript"> alert('Xss done');</script>

            //    ViewBag.ThongBao = "Chúc mừng bạn đăng nhập thành công !";
            //    Session["TaiKhoan"] = kh;
            //    return RedirectToAction("Index","Home");
            //}
            //ViewBag.ThongBao = "Tên tài khoản hoặc mật khẩu không đúng!";
            //return View();

        }

        [HttpGet]
        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Register([Bind(Include = "MaKH,HoTen, NgaySinh, GioiTinh, DienThoai,TaiKhoan, MatKhau,Email,DiaChi")]KhachHang kh)
        {
            if (ModelState.IsValid)
            {
                var checkUserName = db.KhachHangs.Any(s => s.TaiKhoan == kh.TaiKhoan);
                if (checkUserName)
                {
                    ViewBag.thongbao = "Tài khoản đã tồn tại.";
                }
                else
                {
                    ViewBag.thanhcong = "Đăng ký thành công!";
                    //Chèn dữ liệu vào bảng khách hàng
                    db.KhachHangs.Add(kh);
                    //Lưu vào csdl 
                    db.SaveChanges();
                }
            }
            return View();
        }
        //cap nhat thong tin khách hang
        public ActionResult Details(int? id)
        {
            KhachHang khachhang = db.KhachHangs.Find(id);
            ViewBag.GioiTinh = khachhang.GioiTinh;
            return View(khachhang);
        }
        [HttpPost]
       
        public ActionResult Details(KhachHang khachhang)
        {
            try
            {
                ViewBag.GioiTinh = khachhang.GioiTinh;
                if (ModelState.IsValid)
                {
                    foreach (var item in db.KhachHangs.ToList())
                    {
                        if (item.TaiKhoan == khachhang.TaiKhoan)
                        {
                            item.GioiTinh = khachhang.GioiTinh;
                            item.HoTen = khachhang.HoTen;
                            item.MatKhau = khachhang.MatKhau;
                            item.NgaySinh = khachhang.NgaySinh;
                            item.DiaChi = khachhang.DiaChi;
                            item.DienThoai = khachhang.DienThoai;
                            item.Email = khachhang.Email;
                            db.SaveChanges();
                            break;
                        }
                    }
                    //db.Entry(khachhang).State = EntityState.Modified;
                    // KhachHang kh = db.KhachHangs.SingleOrDefault(s => s.TaiKhoan == khachhang.TaiKhoan);

                    ViewBag.thanhcong = "Cập nhật thành công!";
                    //return RedirectToAction("Index");

                }
            }
            catch { }
            return View(khachhang);
        }
        public ActionResult Logout(string urlString)
        {
            //FormsAuthentication.SignOut();
            Session["TaiKhoan"] = null;
            if (urlString.Trim() != "")
                return Redirect(urlString);
            return RedirectToAction("Index", "Home");
        }
        //[HttpPost]
        //public ActionResult KiemTraTK(string inputName)
        //{
        //    //var list = (from s in db.KhachHangs
        //    //           select s).ToList();
        //    //foreach (var item in list)
        //    //{
        //    //    if(name==item.TaiKhoan)
        //    //    {
        //    //        return Json(new { tb = 1 });
        //    //    }
        //    //}
        //    return Json(new { tb = 0 });
        //}
    }
}