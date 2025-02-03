using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace AppBhirtday.Models
{
    //static bir sınıf içerisinde bir list olacak
    //uygulamaya özel static sınıf tek bir objesi var 
    public static class Veritabani
    {
        //dictionary yapma sebebi her bir listenin içerisindeki her bir elemana key verme 
        private static Dictionary<string, Davetiye> _liste;
        static Veritabani()
        {

            //oluşturduğum listeye üç tane eleman ekledim
            _liste = new Dictionary<string, Davetiye>();
            _liste.Add("Hasan", new Davetiye
            {
                Ad = "Hasan",
                Eposta = "hasan@gmail.com",
                KatilmeDurumu = true
            });


            _liste.Add("Mehmet", new Davetiye
            {
                Ad = "Mehmet",
                Eposta = "mehmet@gmail.com",
                KatilmeDurumu = false
            });

            _liste.Add("Berrin", new Davetiye
            {
                Ad = "Berrin",
                Eposta = "berrin@gmail.com",
                KatilmeDurumu = true
            });

          
        }
        public static void Add(Davetiye model)
        {
            string key = model.Ad.ToLower();
            if(_liste.ContainsKey(key))
            {
                _liste[key] = model;
            }
            else
            {
                _liste.Add(key, model);
            }

        }

        //private olan listeyi public haline getirecek
        public static IEnumerable<Davetiye> Liste
        {
            get { return _liste.Values; }
            }
    }
}