using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants.ErrorCodes
{
    public static class ErrorCodes
    {
        public static string GetEmptyFieldErrorCode => "204";
        public static string GetInsufficientLengthErrorCode => "304"; // Yetersiz Uzunluk Hatası
        public static string GetInvalidEmailErrorCode => "301";
        public static string GetNotFoundErrorCode => "404";
        public static string GetNotAuthorizedErrorCode => "405";
        public static string GetAlreadyExistRentalOfSelectedCarErrorCode => "101";
    }
}
