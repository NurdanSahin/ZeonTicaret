using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeonTicaret.WebUI.App_Classes
{
    public class Context
    {
        private static eTicaretContext baglanti;

        public static eTicaretContext Baglanti
        {
            get {
                if (baglanti == null)
                    baglanti = new eTicaretContext();
                return baglanti;
            }
            set { baglanti = value; }
        }

    }
}