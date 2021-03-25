using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService : IBusinessService<CarImage>
    {
        IDataResult<List<CarImage>> GetAllImagesByCarId(int carId);
        IResult AddImage(CarImage entity, IFormFile file);
        IResult UpdateImage(CarImage entity, IFormFile file);
        IResult DeleteImage(int id);
    }
}
