using Core.Entities;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IDal<Rental>
    {
        List<RentalDetailDto> GetRentalDetails();
    }
}
