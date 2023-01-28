using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Device.Location;
using System.Threading;

namespace Controller
{
    public class WeatherApiController
    {
        public void weatherForecast(PictureBox picturebox1,Label labelcity,Label labeltemp,Label labelfeelslike,Label labelclouds,Label labelhumidity,TextBox textboxcity,Label message)
        {
            if (string.IsNullOrEmpty(textboxcity.Text))
            {
                bool whileDurdur = false;
                var watcher = new GeoCoordinateWatcher();
                watcher.Start();
                if (watcher.TryStart(false, TimeSpan.FromMilliseconds(3000)))
                {
                    // Burada watcher nesnesinin durumu hazır değilse konum okuma durumu hazır olana kadar 2 salise 
                    // uyutuyoruz ve daha sonra datetime now substract ile şimdiki zamandan geçen 2 salise uyku süresiyle beraber
                    // çıkartıyoruz ve daha sonra toplam zaman 3 saniyeyi geçmeden while döngüsünü durduruyoruz. Değişkenimizin
                    // değerini true çekiyoruz.
                    DateTime start = DateTime.Now;
                    while (watcher.Status != GeoPositionStatus.Ready && !whileDurdur)
                    {
                        Thread.Sleep(200);
                        if (DateTime.Now.Subtract(start).TotalSeconds > 3)
                        {
                            whileDurdur = true;
                        }
                    }
                    // Konumu alın
                    var coord = watcher.Position.Location;
                    double lat = coord.Latitude;
                    double lon = coord.Longitude;
                    try
                    {
                        message.Text = "";
                        string apppid = "Buraya openweathermap.org dan aldığınız api key";
                        string request = string.Format("https://api.openweathermap.org/data/2.5/weather?lat={0}&lon={1}&mode=xml&units=metric&lang=tr&appid={2}", lat.ToString(), lon.ToString(), apppid);
                        XDocument response = XDocument.Load(request);
                        var icon = response.Descendants("weather").ElementAt(0).Attribute("icon").Value;
                        var temp = response.Descendants("temperature").ElementAt(0).Attribute("value").Value;
                        var cityname = response.Descendants("city").ElementAt(0).Attribute("name").Value;
                        var feels_like = response.Descendants("feels_like").ElementAt(0).Attribute("value").Value;
                        var humidity = response.Descendants("humidity").ElementAt(0).Attribute("value").Value;
                        var humidityunit = response.Descendants("humidity").ElementAt(0).Attribute("unit").Value;
                        var clouds = response.Descendants("clouds").ElementAt(0).Attribute("name").Value;
                        picturebox1.ImageLocation = "http://openweathermap.org/img/wn/" + icon + ".png";
                        labelcity.Text = cityname.ToUpper();
                        labeltemp.Text = "SICAKLIK: " + temp.ToUpper() + "°";
                        labelfeelslike.Text = "HİSSEDİLEN SICAKLIK: " + feels_like.ToUpper() + "°";
                        labelclouds.Text = "DURUM: " + clouds.ToUpper();
                        labelhumidity.Text = "NEM: " + humidity.ToUpper() + " " + humidityunit.ToUpper();
                    }
                    catch (WebException)
                    {
                        message.Text = "Konum bulunamadı !";
                    }
                }
            }
            else
            {
                try
                {
                    message.Text = "";
                    string apppid = "29fb05a22bbc6fbc24f12212fa59fc02";
                    string request = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&mode=xml&units=metric&lang=tr&appid={1}", textboxcity.Text, apppid);
                    XDocument response = XDocument.Load(request);
                    var icon = response.Descendants("weather").ElementAt(0).Attribute("icon").Value;
                    var temp = response.Descendants("temperature").ElementAt(0).Attribute("value").Value;
                    var cityname = response.Descendants("city").ElementAt(0).Attribute("name").Value;
                    var feels_like = response.Descendants("feels_like").ElementAt(0).Attribute("value").Value;
                    var humidity = response.Descendants("humidity").ElementAt(0).Attribute("value").Value;
                    var humidityunit = response.Descendants("humidity").ElementAt(0).Attribute("unit").Value;
                    var clouds = response.Descendants("clouds").ElementAt(0).Attribute("name").Value;
                    picturebox1.ImageLocation = "http://openweathermap.org/img/wn/" + icon + ".png";
                    labelcity.Text = cityname.ToUpper();
                    labeltemp.Text = "SICAKLIK: " + temp.ToUpper() + "°";
                    labelfeelslike.Text = "HİSSEDİLEN SICAKLIK: " + feels_like.ToUpper() + "°";
                    labelclouds.Text = "DURUM: " + clouds.ToUpper();
                    labelhumidity.Text = "NEM: " + humidity.ToUpper() + " " + humidityunit.ToUpper();
                }
                catch (WebException)
                {
                    message.Text = "Konum bulunamadı !";
                }
            }
        }
    }
}
