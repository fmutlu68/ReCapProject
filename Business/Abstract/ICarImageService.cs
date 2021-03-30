using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAllImagesByCarId(int carId);
        IResult AddImage(CarImage entity, IFormFile file);
        IResult UpdateImage(CarImage entity, IFormFile file);
        IResult DeleteImage(int id);
        IResult Add(CarImage entity);
        IResult Delete(CarImage entity);
        IResult Update(CarImage entity);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetById(int id);
    }
}
