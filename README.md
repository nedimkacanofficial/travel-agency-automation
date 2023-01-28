# Seyahat-Acentesi-Otomasyonu
Seyahat Acentesi Otomasyonu

Proje 3 yetkilendirmeden oluşuyor. Projenin sql dosyası execute edildikten sonra veri tabanına ilk personel eklenirken
yetki durumu 0 olarak seçilirse admin yetkisi verilir eğer 1 seçilirse bölge müdürü yetkisi verilir eğer 2 seçilirse
o zaman da en düşük yetkili yazıhane personelleri vb işlemleri yapan personel sisteme giriş yapabilecek.

Projeyi çalıştırmak için öncelikle sql dosyasını sql server management üzerinden çalıştırmalıyız. Daha sonra ise açılan
sql dosyasının en üst satırında yazan use ile başlayan kısım veri tabanı adı burada yazan isimle bir veri tabanı
oluşturduktan sonra bunu execute ile çalıştırmalısın bu artık tablolar ve procedurler veri tabanına yüklenmiş olacak
daha sonra veri tabanı bağlantı kısmını dosya proje dosyasını açıp SqlAccess sınıfında tanımlı olan 
bağlantı cümleciğini kendi bilgilerinize göre dolduracaksınız. 

Ayrıca MailerController içerisindeki mail bölümünden ise kendi mail adresinizi ve gmail tarafından verilen
3 parti key anahtarı ile kendi bilgilerinizi girdikten sonra mailer kısmıda çalışır bir hale gelecek

Hava durumu için ise openweather.com sitesine gidip buradan bir api key almalısınız ve WeatherController 
üzerinden kendi api keyinizi buraya yazdıktan sonra proje sorunsuz bir şekilde çalışacaktır.

Projeyi Hazırlayan

Nedim Kaçan
# Üniversite Nesne Tabanlı 1 Ders Ödevi
