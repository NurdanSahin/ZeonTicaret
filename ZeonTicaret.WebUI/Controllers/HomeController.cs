﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeonTicaret.WebUI.App_Classes;

namespace ZeonTicaret.WebUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public  PartialViewResult Sepet()
        {
            return PartialView();
        }

        public PartialViewResult Slider()
        {
            var data = Context.Baglanti.Resim.Where(x => x.BuyukYol.Contains("Slider")).ToList();
            return PartialView(data);
        }
        public PartialViewResult YeniUrunler()
        {
            var data = Context.Baglanti.Urun.ToList();
            return PartialView(data);
        }
        public PartialViewResult Servisler()
        {
            return PartialView();
        }

        
        public PartialViewResult Markalar()
        {
            var data = Context.Baglanti.Marka.ToList();
            return PartialView(data);
        }
        public void SepeteEkle(int id)
        {
            SepetItem si = new SepetItem();
            Urun u = Context.Baglanti.Urun.FirstOrDefault(x => x.Id == id);
            si.Urun = u;
            si.Adet = 1;
            si.Indirim = 0;
            Sepet s = new Sepet();
            s.SepeteEkle(si);
            MiniSepetWidget();
        }
        public PartialViewResult MiniSepetWidget()
        {
            if (HttpContext.Session["AktifSepet"] != null)
                return PartialView((Sepet)HttpContext.Session["AktifSepet"]);
            else
                return PartialView();
        }
        public void SepetUrunAdetDusur(int id)
        {
            if (HttpContext.Session["AktifSepet"] != null)
            {
                Sepet s = (Sepet)HttpContext.Session["AktifSepet"];

                if (s.Urunler.FirstOrDefault(x => x.Urun.Id == id).Adet > 1)
                {
                    s.Urunler.FirstOrDefault(x => x.Urun.Id == id).Adet--;
                }
                else
                {
                    SepetItem si = s.Urunler.FirstOrDefault(x => x.Urun.Id == id);
                    s.Urunler.Remove(si);
                }
            }
        }
        public ActionResult UrunDetay(string id)
        {
            Urun u = Context.Baglanti.Urun.FirstOrDefault(x => x.Adi == id);
            List<UrunOzellik> uos = Context.Baglanti.UrunOzellik.Where(x => x.UrunId == u.Id).ToList();
        

            return View(u);
        }
    }
}