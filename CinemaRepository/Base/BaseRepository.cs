using System;
using System.Collections.Generic;
using System.Text;
using CinemaRepository.Context;
using CinemaDomain.Base;

namespace CinemaRepository.Base
{
    public class BaseRepository<TypeEntity> : IBaseRepository<TypeEntity> where TypeEntity : BaseEntity
    {
        protected readonly MyDBContext _myDBContext;

        public BaseRepository(MyDBContext myDBContext)
        {
           _myDBContext = myDBContext;
        }

        public void Create(TypeEntity entity)
        {
            _myDBContext.Add(entity);
            _myDBContext.SaveChanges();
        }

        public TypeEntity ReadbyId(int id)
        {
            var dbContext = _myDBContext.Set<TypeEntity>().AsQueryable;
            return dbContext.ToList().Find(x => x.Id == id);
        }

        public IList<TypeEntity> ReadAll()
        {
            var dbContext = _myDBContext.Set<TypeEntity>().AsQueryable;
            return dbContext.ToList();
        }

        public void Update(TypeEntity entity)
        {
            _myDBContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _myDBContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _myDBContext.Remove(ReadbyId(id));
            _myDBContext.SaveChanges();
        }
    }
}