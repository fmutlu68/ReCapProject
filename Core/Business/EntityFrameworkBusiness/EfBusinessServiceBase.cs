using Core.Constants;
using Core.Entities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business.EntityFrameworkBusiness
{
    public class EfBusinessServiceBase<TEntity, TDal> 
        where TEntity: class, IEntity, new()
        where TDal: class, IDal<TEntity>, new()
    {
        public TDal service;

        public EfBusinessServiceBase()
        {
            this.service = new TDal();
        }
        public virtual IResult Add(TEntity entity)
        {
            try
            {
                service.Add(entity);
                return new SuccessResult(Messages.GetCRUDSuccess(GetAll().Data.Count, entity.ToString(),"Ekleme"));
            }
            catch (Exception err)
            {
                return new ErrorResult(Messages.GetCRUDError(err.Message,entity.ToString(),"Ekleme"));
            }
        }
        public virtual IResult Delete(TEntity entity)
        {
            try
            {
                service.Delete(entity);
                return new SuccessResult(Messages.GetCRUDSuccess(GetAll().Data.Count, entity.ToString(), "Silme"));
            }
            catch (Exception err)
            {
                return new ErrorResult(Messages.GetCRUDError(err.Message, entity.ToString(), "Silme"));
            }
        }
        public virtual IResult Update(TEntity entity)
        {
            try
            {
                service.Update(entity);
                return new SuccessResult(Messages.GetCRUDSuccess(GetAll().Data.Count, entity.ToString(), "Güncelleme"));
            }
            catch (Exception err)
            {
                return new ErrorResult(Messages.GetCRUDError(err.Message, entity.ToString(), "Güncelleme"));
            }
        }
        public virtual IDataResult<List<TEntity>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<TEntity>>(Messages.GetEntityListedSuccess,service.GetAll());
            }
            catch (Exception err)
            {
                return new ErrorDataResult<List<TEntity>>(Messages.GetEntityListedError(err.Message));
            }
        }
        public virtual IDataResult<TEntity> Get(int id,string entityName)
        {
            try
            {
                return new SuccessDataResult<TEntity>(Messages.GetEntitySuccess(entityName), service.Get(e => e.Id == id)); 
            }
            catch (Exception err)
            {
                return new ErrorDataResult<TEntity>(Messages.GetCRUDError(err.Message,entityName,"Id'ye Göre Getirme"));
            }
        }
    }
}
