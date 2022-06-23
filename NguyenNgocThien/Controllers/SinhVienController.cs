using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NguyenNgocThien.Models;

namespace NguyenNgocThien.Controllers
{
    public class SinhVienController : Controller
    {
        // GET: SinhVien
        MyDataDataContext data = new MyDataDataContext();
        public ActionResult Index()
        {
            var all_sinhvien = from tt in data.SinhViens select tt;
            return View(all_sinhvien);
        }
        public ActionResult Detail(string id)
        {
            var D_sinhvien = data.SinhViens.Where(m => m.MaSV == id).First();
            return View(D_sinhvien);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, SinhVien tl)
        {
            var ten = collection["HoTen"];
            if (string.IsNullOrEmpty(ten))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                tl.HoTen = ten;
                data.SinhViens.InsertOnSubmit(tl);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Create();
        }
        public ActionResult Edit(string id)
        {
            var S_sinhvien = data.SinhViens.First(p => p.MaSV == id);
            return View(S_sinhvien);
        }

        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            var S_sinhvien = data.SinhViens.First(m => m.MaSV == id);
            var S_mssv = collection["MaSV"];
            var S_hoten = collection["HoTen"];
            var S_gioitinh = collection["GioiTinh"];
            var S_ngaysinh = Convert.ToDateTime(collection["NgaySinh"]);
            var S_hinh = collection["Hinh"];
            var S_manganh = collection["MaNganh"];
            S_sinhvien.MaSV = id;
            if (string.IsNullOrEmpty(S_mssv))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                S_sinhvien.MaSV = S_mssv.ToString();
                S_sinhvien.HoTen = S_hoten.ToString();
                S_sinhvien.GioiTinh = S_gioitinh.ToString();
                S_sinhvien.NgaySinh = S_ngaysinh;
                S_sinhvien.Hinh = S_hinh.ToString();
                S_sinhvien.MaNganh = S_manganh.ToString();
                UpdateModel(S_sinhvien);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }
        //-------------Delete-------------------
        public ActionResult Delete(string id)
        {
            var D_theloai = data.SinhViens.First(m => m.MaSV == id);
            return View(D_theloai);
        }
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            var D_theloai = data.SinhViens.Where(m => m.MaSV == id).First();
            data.SinhViens.DeleteOnSubmit(D_theloai);
            data.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
}