using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string BrandsListed = "Markalar Listelendi";
        public static string GetBrand = "Sectiginiz Marka";
        public static string BrandAdded = "Marka Eklendi";
        public static string BrandUpdated = "Marka Bilgisi Guncellendi";
        public static string BrandDeleted = "Marka Silindi";

        public static string DailyPriceError = "Aracin Fiyati 0 dan buyuk olmalidir";
        public static string CarAdded = "Arac Eklendi";
        public static string CarAddedError = "Arac Ekleme Basarisiz";
        public static string CarsListed = "Araclar Listelendi";
        public static string CarsListedWithDetails = "Araclarin Detaylari Listelendi";
        public static string GetCarByBrandId = "Sectiginiz Markadaki Araclar : ";
        public static string GetCarByColorId = "Sectiginiz Renkteki Araclar : ";
        public static string CharError = "Arac Ismi Minimum 3 Karakterden Olusmalidir";
        public static string CarUpdateError = "Arac Bilgilerini Guncelleme Basarisiz";
        public static string CarUpdated = "Arac Bilgileri Guncellendi";
        public static string CarDeleted = "Arac Veritabanindan Silindi";
        public static string GetCarId = "Sectiginiz  Arac : ";
        public static string CarCountOfBrandError = "Bir Markadan 10 Arac Olabilir";
        public static string CarDescriptionAlreadyExist = "Bu Tanimda Bir Arac Zaten Var";
        public static string BrandLimitExceded = "Marka Limiti Asildigi Icin Yeni Arac Eklenemiyor";

        public static string ColorAdded = "Renk Eklendi";
        public static string ColorDeleted = "Renk Silindi";
        public static string ColorUpdated = "Renk Bilgisi Guncellendi";
        public static string ColorsListed = "Renkler Listelendi";
        public static string GetColor = "Sectiginiz Renk : ";

        public static string CustomerAdded = "Musteri Eklendi";
        public static string CustomerDeleted = "Musteri Silindi";
        public static string CustomerUpdated = "Musteri Bilgisi Guncellendi";
        public static string CustomersListed = "Musteriler Listelendi";
        public static string GetCustomer = "Sectiginiz Musteri : ";

        public static string RentalAdded = "Kiralama Eklendi";
        public static string RentalDeleted = "Kiralama Silindi";
        public static string RentalUpdated = "Kiralama Bilgisi Guncellendi";
        public static string RentalsListed = "Kiralamalar Listelendi";
        public static string GetRental = "Sectiginiz Kiralama : ";

        public static string UserAdded = "Yeni Kullanici Eklendi";
        public static string UserDeleted = "Kullanici Silindi";
        public static string UserUpdated = "Kullanici Bilgisi Guncellendi";
        public static string UsersListed = "Kullanicilar Listelendi";
        public static string GetUser = "Sectiginiz Kullanici : ";
        public static string UsersListedWithDetails = "Kullanicilarin Detaylari Listelendi";

        public static string CarImageAdded = "Resim Ekleme Basarili";
        public static string CarImageDeleted = "Resim Basariyla Silindi";
        public static string CarImagesListed = "Resimler Listelendi";
        public static string CarImagesListedByCarId = "Aracin Resimleri Listelendi";
        public static string CarImageFound = "Baktiginiz Resim : ";
        public static string CarImagesListedWithDetails = "Resim Detaylari : ";
        public static string CarImageUpdated = "Resmin Bilgileri Guncellendi";
        public static string CarImagesOverLimit = "Ayni Arac Icin 5ten Fazla Resim Eklenemez";

        public static string AuthorizationDenied = "Bu Islem Icin Yetkiniz Yok";
        public static string ClaimsListed = "Kullaniciya Ait Claimler Listelendi";
        public static string GetUserByMail = "Bu Maile Sahip Kullanici : ";

        public static string UserRegistered = "Kayit Basarili";
        public static string UserNotFound = "Kullanici Bulunamadi";
        public static string PasswordError = "Hatali Parola";
        public static string UserAlreadyExists = "Kullanici Mevcut";
        public static string SuccessfulLogin = "Basarili Giris";
        public static string AccessTokenCreated = "Token Olusturuldu";

        public static string CarDetailsListed = "Detaylar Listelendi";
        public static string RentalDetaislListed = "Kiralama Detaylari Listelendi";
        public static string CustomerDetailListed = "Musteri Detaylari Listelendi";

    }
}
