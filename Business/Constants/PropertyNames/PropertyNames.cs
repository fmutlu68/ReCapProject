using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants.PropertyNames
{
    public static class PropertyNames
    {
        // Car
        public static string GetCarBrandIdFieldName => "Marka";
        public static string GetCarColorIdFieldName => "Renk";
        public static string GetCarDailyPriceFieldName => "Günlük Kiralama Bedeli";
        public static string GetCarDescriptionFieldName => "Araç Detayı";
        public static string GetCarModelYearFieldName => "Arabanın Modeli";
        // Color
        public static string GetColorColorFieldName => "Renk"; /// ColorName
        // Brand
        public static string GetBrandBrandFieldName => "Marka"; /// <summary>
        /// BrandName
        /// </summary>
        
        // Customer
        public static string GetCustomerCompanyFieldName => "Şirket Adı";
        public static string GetCustomerUserIdFieldName => "Müşteri"; ///UserId

        // Rental
        public static string GetRentalCustomerIdFieldName => "Müşteri"; /// UserId
        public static string GetRentalCarIdFieldName => "Araba"; 
        public static string GetRentalRentDateFieldName => "Kiralama Tarihi"; /// UserId
        public static string GetRentalReturnDateFieldName => "Geri Dönüş Tarihi"; /// UserId

        // User
        public static string GetUserFirstNameFieldName => "Adı";
        public static string GetUserLastNameFieldName => "Soyadı";
        public static string GetUserEmailFieldName => "Email";
        public static string GetUserPasswordFieldName => "Şifre";
    }
}
