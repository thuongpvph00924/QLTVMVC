using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Vinabook.Models;
using PagedList;
using PagedList.Mvc;
using System.Web.Security;

namespace Vinabook.Areas.Administrator.Controllers
{
    [Authorize]
    public class QuanLyDGController : Controller
    {
        // GET: QuanLyKH
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            return View(db.KhachHangs.ToList().OrderBy(n => n.HoTen).ToPagedList(pageNumber, pageSize));
        }
        /// <summary>
        /// Tao moi
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(KhachHang kh)
        {
            //Thêm vào cơ sở dữ liệu  
            if (ModelState.IsValid)
            {
                db.KhachHangs.Add(kh);
                db.SaveChanges();
                ViewBag.ThongBao = "Thêm mới thành công";
            }
            else
            {
                ViewBag.ThongBao = "Thêm mới thất bại";
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int MaKH)
        {
            //Lấy ra đối tượng sách theo mã 
            KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.MaKH == MaKH);
            if (kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.GioiTinh = kh.GioiTinh;
            return View(kh);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(KhachHang kh, FormCollection f)
        {
            //Thêm vào cơ sở dữ liệu
            if (ModelState.IsValid)
            {
                //Thực hiện cập nhận trong model
                db.Entry(kh).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Index");

        }
        /// <summary>
        /// Hien thi
        /// </summary>
        /// <param name="MaSach"></param>
        /// <returns></returns>
        public ActionResult Details(int MaKH)
        {

            //Lấy ra đối tượng sách theo mã 
            KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.MaKH == MaKH);
            if (kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(kh);

        }

        [HttpPost]
        public JsonResult XemCTKH(int makh)
        {
            TempData["makh"] = makh;
            return Json(new { Url = Url.Action("XemCTKHPartial") });
        }
        public PartialViewResult XemCTKHPartial()
        {
            int maKH = (int)TempData["makh"];
            var lstKH = db.KhachHangs.Where(n => n.MaKH == maKH).ToList();
            return PartialView(lstKH);
        }
        /// <summary>
        /// Xoa
        /// </summary>
        /// <param name="MaSach"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Delete(int MaKH)
        {
            //Lấy ra đối tượng sách theo mã 
            KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.MaKH == MaKH);
            if (kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(kh);
        }
        [HttpPost, ActionName("Delete")]

        public ActionResult XacNhanXoa(int MaKH)
        {
            KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.MaKH == MaKH);
            if (kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.KhachHangs.Remove(kh);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult TimKiemKH(int? page, string Key)
        {
            ViewBag.Key = Key;

            //  List<Sach> lsKQTK = db.Saches.Where(m => m.TenSach.Contains(Key)).ToList();           
            List<KhachHang> lsKQTK = db.KhachHangs.Where(n => n.HoTen.Contains(Key) || n.TaiKhoan.Contains(Key)).ToList();
            ViewBag.TuKhoa = Key;
            int pageNumber = (page ?? 1);
            int pageSize = 12;
            if (lsKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy";
                return View(db.KhachHangs.OrderBy(n => n.MaKH).ToPagedList(pageNumber, pageSize));

            }
            //ViewBag.ThongBao = "Đã tìm thấy " + lsKQTK.Count + " kết quả";


            return View(lsKQTK.OrderBy(n => n.MaKH).ToPagedList(pageNumber, pageSize));
        }
        [HttpPost]
        public ActionResult TimKiemKH(FormCollection f, int? page)//string txtTimKiem,int ?page)
        {
            string Key = f["txtTimKiem"].ToString();
            //List<Sach> lsKQTK = db.Saches.Where(m => m.TenSach.Contains(Key)).ToList();
            List<KhachHang> lsKQTK = db.KhachHangs.Where(n => n.HoTen.Contains(Key) || n.TaiKhoan.Contains(Key)).ToList();

            ViewBag.Key = Key;
            int pageNumber = (page ?? 1);
            int pageSize = 12;
            if (lsKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy";
                return View(db.KhachHangs.OrderBy(n => n.MaKH).ToPagedList(pageNumber, pageSize));

            }
            //ViewBag.ThongBao = "Đã tìm thấy " + lsKQTK.Count + " kết quả";


            return View(lsKQTK.OrderBy(n => n.MaKH).ToPagedList(pageNumber, pageSize));
            //return PartialView("TimKiemPartial");
        }
    }
}