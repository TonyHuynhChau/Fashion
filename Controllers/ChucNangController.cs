using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fashion.Models;
using PagedList;

namespace Fashion.Controllers
{
    public class ChucNangController : Controller
    {
        QLBanQuanAoDataContext context = new QLBanQuanAoDataContext();
        public ActionResult DSsanpham(int? page)
        {
            int pagesize = 10;
            int pageNum = (page ?? 1);
            var list = context.SANPHAMs.OrderByDescending(s => s.MaSP).ToList();
            return View(list.ToPagedList(pageNum, pagesize));
        }

        public ActionResult DSGOPY(int? page)
        {
            if (Session["TKAdmin"] == null)
            {
                return RedirectToAction("Index", "Fashion");
            }
            else
            {
                int pagesize = 10;
                int pageNum = (page ?? 1);
                var list = context.HoTros.OrderByDescending(s => s.MaKH).ToList();
                return View(list.ToPagedList(pageNum, pagesize));
            }
        }

        public ActionResult GOPY_CHITIET(int id)
        {
            HoTro ht = context.HoTros.SingleOrDefault(n => n.MaKH == id);
            ViewBag.MaKH = ht.MaKH;
            if(ht == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ht);
        }

        public ActionResult DSKH(int? page)
        {
            if (Session["TKAdmin"] == null)
            {
                return RedirectToAction("Index", "Fashion");
            }
            else
            {
                int pagesize = 10;
                int pageNum = (page ?? 1);
                var list = context.KHACHHANGs.OrderByDescending(s => s.MaKH).ToList();
                return View(list.ToPagedList(pageNum, pagesize));
            }
        }
        public ActionResult DSNCC(int? page)
        {
            if (Session["TKAdmin"] == null)
            {
                return RedirectToAction("Index", "Fashion");
            }
            else
            {
                int pagesize = 10;
                int pageNum = (page ?? 1);
                var list = context.NCCs.OrderByDescending(s => s.MaNCC).ToList();
                return View(list.ToPagedList(pageNum, pagesize));
            }
        }

        [HttpGet]
        public ActionResult ThemNCC()
        {
            if (Session["TKAdmin"] == null)
            {
                return RedirectToAction("Index", "Fashion");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult ThemNCC(NCC ncc)
        {
            if (Session["TKAdmin"] == null)
            {
                return RedirectToAction("Index", "Fashion");
            }
            else
            {
                context.NCCs.InsertOnSubmit(ncc);
                context.SubmitChanges();
                return RedirectToAction("DSNCC", "ChucNang");
            }
        }

        [HttpGet]
        public ActionResult XoaNCC(int id)
        {
            if (Session["TKAdmin"] == null)
            {
                return RedirectToAction("Index", "Fashion");
            }
            else
            {
                NCC ncc = context.NCCs.SingleOrDefault(n => n.MaNCC == id);
                ViewBag.MaNCC = ncc.MaNCC;
                if (ncc == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                return View(ncc);
            }
        }
        [HttpPost, ActionName("XoaNCC")]
        public ActionResult XacNhanXoa(int id)
        {
            if (Session["TKAdmin"] == null)
            {
                return RedirectToAction("Index", "Fashion");
            }
            else
            {
                NCC ncc = context.NCCs.SingleOrDefault(n => n.MaNCC == id);
                ViewBag.MaNCC = ncc.MaNCC;
                if (ncc == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                context.NCCs.DeleteOnSubmit(ncc);
                context.SubmitChanges();
                return RedirectToAction("DSNCC");
            }
        }

        [HttpGet]
        public ActionResult SuaNCC(int id)
        {
            if (Session["TKAdmin"] == null)
            {
                return RedirectToAction("Index", "Fashion");
            }
            else
            {
                NCC ncc = context.NCCs.SingleOrDefault(n => n.MaNCC == id);
                if (ncc == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                return View(ncc);
            }
        }

        [HttpPost, ActionName("SuaNCC")]
        public ActionResult XacNhanSua(int id)
        {
            if (Session["TKAdmin"] == null)
            {
                return RedirectToAction("Index", "Fashion");
            }
            else
            {
                NCC ncc = context.NCCs.SingleOrDefault(n => n.MaNCC == id);
                ViewBag.MaNCC = ncc.MaNCC;
                if (ncc == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                UpdateModel(ncc);
                context.SubmitChanges();
                return RedirectToAction("DSNCC");
            }
        }
    }
}   