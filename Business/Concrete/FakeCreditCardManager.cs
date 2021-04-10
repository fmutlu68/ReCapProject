using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class FakeCreditCardManager : ICreditCardService
    {
        /// <summary>
        /// 1 ==> PaymentIsSuccessful
        /// 0 ==> PaymentIsNotSuccessful
        /// </summary>
        /// <param name="creditCard"></param>
        /// <param name="paymentAmount"></param>
        /// <returns></returns>
        public int Pay(CreditCard creditCard, double paymentAmount)
        {
            if (ValidateCurrentCreditCard(creditCard))
            {
                if (paymentAmount>0)
                {
                    return 1;
                }
                return 0;
            }
            return 0;
        }

        /// <summary>
        /// 1 ==> PaymentIsSuccessful
        /// 0 ==> PaymentIsNotSuccessful
        /// </summary>
        /// <param name="creditCard"></param>
        /// <param name="paymentAmount"></param>
        /// <returns></returns>
        public int PayBack(CreditCard creditCard, double willPayBackAmount)
        {
            if (ValidateCurrentCreditCard(creditCard))
            {
                if (willPayBackAmount > 0)
                {
                    return 1;
                }
                return 0;
            }
            return 0;
        }

        public bool ValidateCurrentCreditCard(CreditCard creditCard)
        {
            if (creditCard.CVV.Length == 3 && creditCard.CartOwner.Length > 0 && creditCard.CartNumber.Length == 18 && creditCard.ExpirationDate > DateTime.Now)
            {
                return true;
            }
            return false;
        }
    }
}
