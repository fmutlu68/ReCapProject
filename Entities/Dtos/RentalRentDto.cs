using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class RentalRentDto : IDto
    {
        public Rental CurrentRental { get; set; }
        public CreditCard CurrentCreditCard { get; set; }
        public double PaymentAmount { get; set; }
    }
}
