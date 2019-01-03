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
    public class QLMuonTras1Controller : Controller
    {
        private QuanLyBanSachEntities db = new QuanLyBanSachEntities();

        // GET: QLMuonTras1
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            return View(db.QLMuonTras.ToList().OrderBy(n => n.MaMuonTra).ToPagedList(pageNumber, pageSize));
        }

        // GET: QLMuonTras1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QLMuonTra qLMuonTra = db.QLMuonTras.Find(id);
            if (qLMuonTra == null)
            {
                return HttpNotFound();
            }
            return View(qLMuonTra);
        }

        // GET: QLMuonTras1/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TaiKhoan");
            ViewBag.MaSach = new SelectList(db.Saches, "MaSach", "TenSach");
            return View();
        }

        // POST: QLMuonTras1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaMuonTra,MaKH,MaSach,NgayMuon,NgayTra,TrangThai")] QLMuonTra qLMuonTra)
        {
            if (ModelState.IsValid)
            {
                db.QLMuonTras.Add(qLMuonTra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TaiKhoan", qLMuonTra.MaKH);
            ViewBag.MaSach = new SelectList(db.Saches, "MaSach", "TenSach", qLMuonTra.MaSach);
            return View(qLMuonTra);
        }

        // GET: QLMuonTras1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QLMuonTra qLMuonTra = db.QLMuonTras.Find(id);
            if (qLMuonTra == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TaiKhoan", qLMuonTra.MaKH);
            ViewBag.MaSach = new SelectList(db.Saches, "MaSach", "TenSach", qLMuonTra.MaSach);
            return View(qLMuonTra);
        }

        // POST: QLMuonTras1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaMuonTra,MaKH,MaSach,NgayMuon,NgayTra,TrangThai")] QLMuonTra qLMuonTra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qLMuonTra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TaiKhoan", qLMuonTra.MaKH);
            ViewBag.MaSach = new SelectList(db.Saches, "MaSach", "TenSach", qLMuonTra.MaSach);
          
            return View(qLMuonTra);
        }

        // GET: QLMuonTras1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QLMuonTra qLMuonTra = db.QLMuonTras.Find(id);
            if (qLMuonTra == null)
            {
                return HttpNotFound();
            }
            return View(qLMuonTra);
        }

        // POST: QLMuonTras1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QLMuonTra qLMuonTra = db.QLMuonTras.Find(id);
            db.QLMuonTras.Remove(qLMuonTra);
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
     
    }
}
