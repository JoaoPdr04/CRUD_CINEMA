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

        protected virtual IQueryable<TypeEntity> Consulta()
        {
            IQueryable<TypeEntity> query = _myDBContext.Set<TypeEntity>().AsNoTracking();

            var entityType = _myDBContext.Model.FindEntityType(typeof(TypeEntity));
            if (entityType != null)
            {
                foreach (var navegacao in entityType.GetNavigations())
                {
                    query = query.Include(navegacao.Name);
                    foreach (var subNavegacao in navegacao.TargetEntityType.GetNavigations()
                                 .Where(n => !n.IsCollection && n.TargetEntityType != entityType))
                    {
                        query = query.Include($"{navegacao.Name}.{subNavegacao.Name}");
                    }
                }
            }
            return query;
        }

        private void AnexarRelacionamentos(TypeEntity entity)
        {
            var entityType = _myDBContext.Model.FindEntityType(typeof(TypeEntity));
            if (entityType == null) return;

            foreach (var navegacao in entityType.GetNavigations().Where(n => !n.IsCollection))
            {
                var propriedade = navegacao.PropertyInfo;
                if (propriedade?.GetValue(entity) is not BaseEntity relacionado || relacionado.Id == 0)
                    continue;

                var rastreada = _myDBContext.ChangeTracker.Entries()
                    .Select(e => e.Entity)
                    .OfType<BaseEntity>()
                    .FirstOrDefault(e => e.GetType() == relacionado.GetType() && e.Id == relacionado.Id);

                if (rastreada != null)
                    propriedade.SetValue(entity, rastreada);
                else
                    _myDBContext.Attach(relacionado);
            }
        }

        public void Create(TypeEntity entity)
        {
            AnexarRelacionamentos(entity);
            _myDBContext.Add(entity);
            _myDBContext.SaveChanges();
        }

        public TypeEntity ReadbyId(int id)
        {
            return Consulta().FirstOrDefault(x => x.Id == id);
        }

        public IList<TypeEntity> ReadAll()
        {
            return Consulta().ToList();
        }

        public void Update(TypeEntity entity)
        {
            var local = _myDBContext.Set<TypeEntity>()
                                    .Local
                                    .FirstOrDefault(entry => entry.Id.Equals(entity.Id));

            if (local != null)
            {
                _myDBContext.Entry(local).State = EntityState.Detached;
            }

            AnexarRelacionamentos(entity);
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
