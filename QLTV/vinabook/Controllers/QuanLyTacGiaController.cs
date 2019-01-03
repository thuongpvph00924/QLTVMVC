using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vinabook.Models;

namespace Vinabook.Controllers
{
    public class QuanLyTacGiaController : Controller
    {
        private QuanLyBanSachEntities db = new QuanLyBanSachEntities();

        // GET: QuanLyTacGia
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            return View(db.TacGias.ToList().OrderBy(n => n.MaTacGia).ToPagedList(pageNumber, pageSize));
        }

        // GET: QuanLyTacGia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TacGia tacGia = db.TacGias.Find(id);
            if (tacGia == null)
            {
                return HttpNotFound();
            }
            return View(tacGia);
        }

        // GET: QuanLyTacGia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuanLyTacGia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTacGia,TenTacGia,DiaChi,TieuSu,DienThoai")] TacGia tacGia)
        {
            if (ModelState.IsValid)
            {
                db.TacGias.Add(tacGia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tacGia);
        }

        // GET: QuanLyTacGia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TacGia tacGia = db.TacGias.Find(id);
            if (tacGia == null)
            {
                return HttpNotFound();
            }
            return View(tacGia);
        }

        // POST: QuanLyTacGia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTacGia,TenTacGia,DiaChi,TieuSu,DienThoai")] TacGia tacGia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tacGia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tacGia);
        }

        // GET: QuanLyTacGia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TacGia tacGia = db.TacGias.Find(id);
            if (tacGia == null)
            {
                return HttpNotFound();
            }
            return View(tacGia);
        }

        // POST: QuanLyTacGia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TacGia tacGia = db.TacGias.Find(id);
            db.TacGias.Remove(tacGia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        [HttpGet]
        public ActionResult TimKiemTacGia(int? page, string Key)
        {
            ViewBag.Key = Key;
            List<TacGia> lsKQTK = db.TacGias.Where(n => n.TenTacGia.Contains(Key) || n.DiaChi.Contains(Key)).ToList();
            ViewBag.TuKhoa = Key;
            int pageNumber = (page ?? 1);
            int pageSize = 12;
            if (lsKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy";
                return View(db.TacGias.OrderBy(n => n.MaTacGia).ToPagedList(pageNumber, pageSize));
            }
            return View(lsKQTK.OrderBy(n => n.MaTacGia).ToPagedList(pageNumber, pageSize));
        }
        [HttpPost]
        public ActionResult TimKiemTacGia(FormCollection f, int? page)//string txtTimKiem,int ?page)
        {
            string Key = f["txtTimKiem"].ToString();
            List<TacGia> lsKQTK = db.TacGias.Where(n => n.TenTacGia.Contains(Key) || n.DiaChi.Contains(Key)).ToList();


            ViewBag.Key = Key;
            int pageNumber = (page ?? 1);
            int pageSize = 12;
            if (lsKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy";
                return View(db.TacGias.OrderBy(n => n.MaTacGia).ToPagedList(pageNumber, pageSize));
            }
            return View(lsKQTK.OrderBy(n => n.MaTacGia).ToPagedList(pageNumber, pageSize));
        }
    }
}
