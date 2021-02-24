using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Constants
{
    public static class Messages
    {
        public static string GetEntityListedSuccess => "Listeleme İşlemi Başarılı";
        public static string GetEntityListedError(string errorMessage)
        {
            return string.Format("Listeleme İşlemi Sırasında Bir Hata Oluştu: {0}", errorMessage);
        }
        public static string GetEntitySuccess(string entityMessage)
        {
            return string.Format("Numarasına Göre {0} Getirme İşlemi Başarılı.", entityMessage);
        }
        public static string GetCRUDSuccess (int count, string entityName, string operationName)
        {
            return string.Format("{0} {1} İşlemi Başarılı. Toplam {2} Sayısı: {3}", entityName, operationName, entityName, count);
        }
        /// Get Add, Update, Delete Error Message
        public static string GetCRUDError(string errorMessage, string entityName, string operationName)
        {
            return string.Format("{0} {1} Esnasında Bir Hata Oluştu: {2}", entityName,operationName, errorMessage);
        }
    }
}
