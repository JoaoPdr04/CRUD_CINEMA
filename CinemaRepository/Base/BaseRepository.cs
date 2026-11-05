using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CinemaDomain.Base;
using CinemaRepository.Context;
using Microsoft.EntityFrameworkCore;

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
            // O AsNoTracking evita que o EF Core prenda o objeto na memória durante a leitura
            return _myDBContext.Set<TypeEntity>()
                               .AsNoTracking()
                               .FirstOrDefault(x => x.Id == id);
        }

        public IList<TypeEntity> ReadAll()
        {
            return _myDBContext.Set<TypeEntity>()
                               .AsNoTracking()
                               .ToList();
        }

        public void Update(TypeEntity entity)
        {
            // Procura se o DbContext já possui essa entidade rastreada em memória
            var local = _myDBContext.Set<TypeEntity>()
                                    .Local
                                    .FirstOrDefault(entry => entry.Id.Equals(entity.Id));

            // Se existir, remove o rastreamento antigo para dar lugar à nova alteração
            if (local != null)
            {
                _myDBContext.Entry(local).State = EntityState.Detached;
            }

            _myDBContext.Entry(entity).State = EntityState.Modified;
            _myDBContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _myDBContext.Set<TypeEntity>().Find(id);
            if (entity != null)
            {
                _myDBContext.Remove(entity);
                _myDBContext.SaveChanges();
            }
        }
    }
}