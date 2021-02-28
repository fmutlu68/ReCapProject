using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants.ErrorMessages
{
    public static class ErrorMessages
    {
        // Brand
        public static string GetEmptyBrandNameError => "Marka Adını Girmek Zorunludur.";
        public static string GetMinLengthBrandNameError => "Marka Adı En Az 2 Karakterden Oluşmalıdır.";

        // Color
        public static string GetEmptyColorNameError => "Renk Adını Girmek Zorunludur.";
        public static string GetMinLengthColorNameError => "Renk Adı En Az 2 Karakterden Oluşmalıdır.";

        // Car
        public static string GetEmptyColorIdError => "Bir Renk Seçilmelidir/Girilmelidir.";
        public static string GetEmptyBrandIdError => "Bir Marka Seçilmelidir/Girilmelidir.";
        public static string GetEmptyDailyPriceError => "Bir Günlük Kiralama Girilmelidir";
        public static string GetInsufficientDailyPriceError => "Girilen Günlük Kiralama Bedeli En Az 20 TL Olmalıdır.";
        public static string GetEmptyDescriptionError => "Araç Detayı Girilmelidir";
        public static string GetEmptyModelYearError => "Arabaya Bir Üretim Yılı Girilmelidir";
        public static string GetInvalidModelYearError => "Üretim Yılı Bir Yıl Olarak Girilmelidir.";

        // Customer
        /// This Field For Both Rental And Customer
        public static string GetEmptyCustomerIdError => "Bir Müşteri Seçilmelidir/Girilmelidir."; 

        // Rental
        public static string GetEmptyCarIdError => "Bir Araba Seçilmelidir.";
        public static string GetEmptyRentDateError => "Bir Kiralama Tarihi Seçilmelidir/Girilmelidir.";
        public static string GetInvalidRentDateError => "Girilen/Seçilen Tarih Bugün'den Sonraki Bir Gün Olmalıdır.";

        // User
        public static string GetEmptyEmailError => "Bir Email Girilmelidir.";
        public static string GetInvalidEmailError => "Geçerli Bir Email Girilmelidir.";
        public static string GetEmptyFirstNameError => "Bir İsim Girilmelidir.";
        public static string GetMinLengthFirstNameError => "Girilen İsim En Az İki Karakterden Oluşmalıdır.";
        public static string GetEmptyLastNameError => "Bir Soyisim Girilmelidir.";
        public static string GetMinLengthLastNameError => "Girilen Soyisim En Az İki Karakterden Oluşmalıdır.";
        public static string GetEmptyPasswordError => "Bir Şifre Girilmelidir.";
        public static string GetMinLengthPasswordError => "Girilen Şifre En Az 8 Karakter Olmalıdır.";
    }
}
