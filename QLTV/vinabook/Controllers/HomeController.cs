using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vinabook.Models;
using PagedList;
using PagedList.Mvc;

namespace Vinabook.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public ActionResult Index()//int? page)
        {

            //Tạo biến số sản phẩm trên trang
            //int pageSize = 9;
            //Tạo biến số trang
            //int pageNumber = (page ?? 1);
            //return View(db.Saches.Where(n => n.Moi == 1).OrderBy(n => n.GiaBan).ToPagedList(pageNumber, pageSize));
            return View();

        }
        public ActionResult SachMoi_Partial()
        {
            return PartialView(db.Saches.Where(n => n.Moi == 1).ToList());
        }
        public ActionResult SachbanChay_Partial()
        {
            return PartialView(db.Saches.OrderBy(e => e.SoLuongTon).Take(10).ToList());
        }
        public ActionResult CoTheBanQuanTam_Partial()
        {
            return PartialView(db.Saches.OrderBy(e => Guid.NewGuid()).Take(10).ToList());
        }
        //Danh sách đơn hàng Menu Hỗ trợ
        [HttpPost]
        public ActionResult HoTro()
        {
            return Json(new { Url = Url.Action("HoTroSuccess_Partial") });
        }
       
      
        [HttpPost]
        public ActionResult HoTroDetails(int MaDonHang)
        {
            TempData["MaDonHang"] = MaDonHang;
            return Json(new { Url = Url.Action("HoTroDetailsSuccess_Partial") });
        }
       
        [HttpPost]
        public ActionResult Check(string MaDH, string Sdt)
        {
            TempData["MaDH"] = MaDH.ToString().Trim();
            TempData["Sdt"] = Sdt;
            return Json(new { Url = Url.Action("Check_Success_Partial") });
        }

       
       
        [HttpPost]
        public ActionResult TroVe()
        {
            return Json(new { Url = Url.Action("TroVe_Partial") });
        }
        public ActionResult TroVe_Partial()
        {
            return PartialView("_Partial_Body_Dialog");
        }
        [HttpPost]
        public ActionResult GoogleMap()
        {
            return Json(new { Url = Url.Action("GoogleMap_Success_Partial") });
        }
        public ActionResult GoogleMap_Success_Partial()
        {
            return PartialView();
        }
        
    }
}