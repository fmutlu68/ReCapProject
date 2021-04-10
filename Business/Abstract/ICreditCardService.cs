using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        int Pay(CreditCard creditCard, double paymentAmount);
        int PayBack(CreditCard creditCard, double willPayBackAmount);
        bool ValidateCurrentCreditCard(CreditCard creditCard);

    }
}
