using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controller
{
    public class MailerController
    {
        public string sendMail(string targetName,string targetSurname,string targetMail,string targetPhone,string fromCity,string toCity,string depertureDate,string carPlate,string seatNo,string totalAmount)
        {
            try
            {
                MailAddress addressFrom = new MailAddress("Buraya mail adresi giriniz");
                MailAddress addressTo = new MailAddress(targetMail);
                MailMessage mess = new MailMessage(addressFrom, addressTo);
                mess.Subject = "KEYF TURİZM BİLET BİLGİLERİ";
                string htmlString = "<html>"+
                                     "<head>"+
                                         "<meta http-equiv='Content-Type' content='text/html; charset=utf-8' />"+
                                         "<style type='text/css'>"+
                                             ".onayla {"+
                                                 "background-color: #3CB371;"+
                                                 "cursor: pointer;"+
                                                 "height: 50px; "+
                                                 "width: 398px; "+
                                                 "color: #FFFFFF;"+
                                             "}"+
                                             ".onayla:hover {"+
                                                 "background-color: #66CDAA;"+
                                             "}"+
                                             ".onayla:active {"+
                                                 "background-color: #2E8B57;"+
                                             "}"+
                                             ".onayla a {"+
                                                 "text-decoration: none; "+
                                                 "color: white; "+
                                                 "width: 100%; "+
                                                 "height: 100%; "+
                                                 "display: block; "+
                                                 "padding -top: 13px; "+
                                                 "overflow: hidden; "+
                                             "}"+
                                             ".mutabikdegil {"+
                                                 "background-color: #FA8072;"+
                                                 "cursor: pointer; "+
                                                 "height: 50px; "+
                                                 "width: 400px; "+
                                                 "color: #FFFFFF;"+
                                             "}"+
                                             ".mutabikdegil:hover {"+
                                                 "background-color: #FFA07A;"+
                                             "}"+

                                             ".mutabikdegil:active {"+
                                                 "background-color: #CD5C5C;"+
                                             "}"+
                                             ".mutabikdegil a {"+
                                                 "text-decoration: none; "+
                                                 "color: white; "+
                                                 "width: 100%; "+
                                                 "height: 100%; "+
                                                 "display: block; "+
                                                 "padding -top: 13px; "+
                                                 "overflow: hidden; "+
                                             "}"+
                                             ".ilgilikisidegil {"+
                                                 "background-color: #1E90FF;"+
                                                 "cursor: pointer; "+
                                                 "color: #FFFFFF;"+
                                                 "width: 800px; "+
                                                 "height: 50px; "+
                                             "}"+
                                             ".ilgilikisidegil:hover {"+
                                                 "background-color: #00BFFF;"+
                                             "}"+
                                             ".ilgilikisidegil:active {"+
                                                 "background-color: #0000FF;"+
                                             "}"+
                                             ".ilgilikisidegil a {"+
                                                 "text-decoration: none; "+
                                                 "color: white; "+
                                                 "width: 100%; "+
                                                 "height: 100%; "+
                                                 "display: block; "+
                                                 "padding -top: 13px; "+
                                                 "overflow: hidden; "+
                                             "}"+
                                         "</style>"+
                                     "</head>"+
                                     "<body>"+
                                         "<table border='1' cellpadding='0' cellspacing='0' align='center'>"+
                                             "<tr> "+
                                                "<td align='center' style='height:50px; width:800px;' bgcolor='3CB371'>"+
                                                    "<b> "+
                                                         "<font color='FFFFFF'>KEYF TURİZM OTOBÜS BİLETİ FATURASI</font>"+
                                                     "</b>"+
                                                "</td>"+
                                             "</tr>"+
                                         "</table>"+
                                         "<table border='1' cellpadding='0' cellspacing='0' align='center'>"+
                                             "<tr>"+
                                                 "<td align='left' height='100' width='400'>"+
                                                    "<b>GÖNDEREN:KEYF TURİZM</b><br>"+
                                                    "<b>ŞUBE:GENEL MERKEZ</b><br>"+
                                                    "<b>TELEFON: 05071769996</b>"+
                                                "</td>"+
                                                " <td align='left' height='100' width='398'>"+
                                                    "<b>ALICI: " + targetName + " " + targetSurname + "</b><br>"+
                                                    "<b>TELEFON: " + targetPhone + " </b><br>"+
                                                    "<b>E MAİL: " + targetMail + "</b>"+
                                                "</td>"+
                                             "</tr>"+
                                         "</table>"+
                                         "<table border='1' cellpadding='0' cellspacing='0' align='center'>"+
                                             "<td align='center' height='30' width='800' bgcolor='DCDCDC'><b>BİLET BİLGİLERİ</b></td>"+
                                         "</table>"+
                                         "<table border='1' cellpadding='0' cellspacing='0' align='center'>"+
                                             "<td align='right' height='100' width='200' bgcolor='DCDCDC'>"+
                                                "<b>NEREDEN:</b><br>"+
                                                "<b>NEREYE:</b><br>"+
                                                "<b>KALKIŞ TARİH:</b><br>"+
                                                "<b>ARAC PLAKA</b><br>"+
                                                "<b>KOLTUK NO:</b><br>"+
                                                "<b>TUTAR:</b>"+
                                            "</td>"+
                                             "<td align='left' height='100' width='598' style='padding-left: 5px;'>"+
                                                "<b>" + fromCity + "</b><br>"+
                                                "<b>" + toCity + "</b><br>"+
                                                "<b>" + depertureDate + "</b><br>"+
                                                "<b>" + carPlate + "</b><br>"+
                                                "<b>" + seatNo + "</b><br>"+
                                                "<b>" + totalAmount + "</b>"+
                                            "</td>"+
                                         "</table>"+
                                         "<table border='1' cellpadding='0' cellspacing='0' align='center'>"+
                                             "<td height='100' width='800' align='center'> "+
                                                "<b>"+
                                                    "Lütfen belirtilen tarih ve saatte belirtin peronda hazır bulununuz.<br>"+
                                                    "Aksi takdirde biletiniz iptal olacaktır.<br>"+
                                                    "Biletinizin iptal olması durumunda haklarınızdan yararlanamazsınız.<br>"+
                                                    "İYİ YOLCULUKLAR DİLERİZ."+
                                                "</b>"+
                                             "</td>"+
                                         "</table>"+
                                     "</body>"+
                                     "</html>";
                mess.IsBodyHtml = true;
                mess.Body = htmlString;

                SmtpClient client = new SmtpClient();
                client.Credentials = new System.Net.NetworkCredential(addressFrom.ToString(), "Buraya gmailden aldığınız 3. parti uygulama şifrenizi girin");
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;
                client.Send(mess);
                return targetMail + " adresine bilet bilgileri başarılı bir şekilde gönderildi !";
            }
            catch (Exception hata)
            {
                return hata.ToString();
            }
        }
    }
}
