using AppBhirtday.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppBhirtday.Controllers
{
    public class DavetiyeController : ApiController
    {
        //katılacakları bir liste haline getiriyor tipi de Davetiye türünde olan veriyi gönderiyor
        //dikkat edelim bir view gönderemiyoruz yani görüntü kullanıcıya gitmiyor
        //kullanıcıya ne gidiyor xml , json gidebilir ; dolayısıyla bu tipte bir veri göndermem demek farklı platformlarda
        //oluşturulan uygulamalara veri gönderebilmek demek 

        //1.durum : [HttpGet] yazarsan bunun get methodu olduğunu anlar
        //[HttpGet]
        public IEnumerable<Davetiye> GetKatilanlar()
        {
            return Veritabani.Liste.Where(m => m.KatilmeDurumu == true);
        }

        //diyelim ki katılmayanları da çalıştıran bi get metodu var , şimdi ikiside get olduğu için anlayamaz bunun içinde işte
        //webApiConfig de action metodunun adını da belirtiyoruz 
        // routeTemplate: "api/{controller}/{action}/{id}",
        public IEnumerable<Davetiye> GetKatilmayanlar()
        {
            return Veritabani.Liste.Where(c => c.KatilmeDurumu == false);
        }


        //1:durum [HttpPost]  yazarsan bunun post metodu olduğunu anlar 
        //[HttpPost] 
        public void Ekle(Davetiye model)
        {
            //şartları kontrol ediyor mesela boş geçilmemesini eğer şartlar sağlanıyorsa ekliyor 
            if (ModelState.IsValid)
            {
                Veritabani.Add(model);
            }
           
        }
        //şimdi iki tane method oluşturduk bu uygulamayı çalıştırınca bu controllere nasıl ulaşacağız 
        //webapiconfig içerisinde ki  routeTemplate söylüyor ;api/controlleradi/id 
        //1.durum : şimdi ilk olarak orda metod adı yok ya ilk başta  routeTemplate: "api/{controller}/{id}", yani böyle 
        //hangi metodu seçeceğini bilemez ama başına get ve post yazarsak action metodu belirtmemize gerek yok

        //2.durum : hangisinin get veya post olduğunu belirtmek için bu yöntemde var başıan get yazılırsa 
        //public IEnumerable<Davetiye> GetKatilanlar()
        //{
        //    return Veritabani.Liste.Where(m => m.KatilmeDurumu == true);
        //}

        //public void PostEkle(Davetiye model)
        //{
        //    //şartları kontrol ediyor mesela boş geçilmemesini eğer şartlar sağlanıyorsa ekliyor 
        //    if (ModelState.IsValid)
        //    {
        //        Veritabani.Add(model);
        //    }

        //}


    }
}
