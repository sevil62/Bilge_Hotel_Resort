using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Project.COMMON.Tools
{
    public static class ImageUploader
    {
        //Metodumuz Geriye string deger döndürecek...
        //HttpPostedFileBase=> MVC'de bir dosya post edilmek isteniyorsa bu tipteki bir nesne tarafından karsılanır

        //Asagıdaki HttpPostedFileBase tipini cagırabilmek icin System.Web kütüphanesini eklemeyi unutmayın
        public static string UploadImage(string serverPath, HttpPostedFileBase file)
        {
            if (file != null)
            {
                Guid uniqueName = Guid.NewGuid();
                // ~/Pictures/asadda/asdasdasdasdasd.jpg
                // ~ bulundugumuz kök dizini anlamına gelir...
                // MVC'de ~ karakteri normal bir şekilde kök dizine çık olarak @Url.Action kullanmadıgınız sürece algılanmaz... Dolayısıyla bu string karakteri kaldırarak path'i düzenlememiz gerekir...

                serverPath = serverPath.Replace("~", string.Empty);
                string[] fileArray = file.FileName.Split('.'); //Split metodu size gelen bir string ifadeyi sizin belirlediginiz bir karakterden itibaren elemanlara boler (bilimKurgu.starWars.uzayGemisi.jpg) ifadesini . ile böldgümüzde karsımıza 4 elemanlı bir dizi cıkar bilimKurgu,starWars,uzayGemisi,jpg
                string extension = fileArray[fileArray.Length - 1].ToLower();

                string fileName = $"{uniqueName}.{extension}";

                if (extension == "jpg" || extension == "gif" || extension == "png" || extension == "jpeg")
                {
                    //Alt taraftaki File, System.IO kütüphanesi ile cagrılmaktadır...
                    //System.IO kütüphanesi sizin C# programlama dilinizin ilgili server'daki dosyalara müdahale edebilmesini saglar...
                    if (File.Exists(HttpContext.Current.Server.MapPath(serverPath + fileName)))
                    {
                        return "1"; //Ancak Guid kullandıgımız icin aslında aynı ismin tekrarlanmaması konusunda bayagı güvendeyiz...Yine de 1'i yani dosya zaten var kodunu burada Algoritmik olarak cagırmak durumundayız...

                    }

                    string filePath = HttpContext.Current.Server.MapPath(serverPath + fileName);
                    file.SaveAs(filePath);
                    return serverPath + fileName;

                }

                return "2"; //secilen dosyanın uzantısı bizim istedigimiz gibi degil...





            }

            return "3"; //dosya null...
        }
    }
}
