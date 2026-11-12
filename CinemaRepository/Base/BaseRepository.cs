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

        // Consulta sem rastreamento, já trazendo as propriedades de navegação
        // (ex.: o Genero de um Filme). Sem o Include, filme.Genero vinha sempre nulo.
        protected virtual IQueryable<TypeEntity> Consulta()
        {
            IQueryable<TypeEntity> query = _myDBContext.Set<TypeEntity>().AsNoTracking();

            var entityType = _myDBContext.Model.FindEntityType(typeof(TypeEntity));
            if (entityType != null)
            {
                foreach (var navegacao in entityType.GetNavigations())
                {
                    query = query.Include(navegacao.Name);
                }
            }
            return query;
        }

        // Os relacionamentos (ex.: o Genero de um Filme) JÁ EXISTEM no banco.
        // Sem isto, o EF tenta INSERIR o Genero junto com o Filme e dá
        // "duplicar valor da chave viola a restrição PK_Genero".
        private void AnexarRelacionamentos(TypeEntity entity)
        {
            var entityType = _myDBContext.Model.FindEntityType(typeof(TypeEntity));
            if (entityType == null) return;

            foreach (var navegacao in entityType.GetNavigations().Where(n => !n.IsCollection))
            {
                var propriedade = navegacao.PropertyInfo;
                if (propriedade?.GetValue(entity) is not BaseEntity relacionado || relacionado.Id == 0)
                    continue;

                // Se o DbContext já rastreia esse registro, reaproveita a mesma instância
                var rastreada = _myDBContext.ChangeTracker.Entries()
                    .Select(e => e.Entity)
                    .OfType<BaseEntity>()
                    .FirstOrDefault(e => e.GetType() == relacionado.GetType() && e.Id == relacionado.Id);

                if (rastreada != null)
                    propriedade.SetValue(entity, rastreada);
                else
                    _myDBContext.Attach(relacionado); // existente: fica Unchanged (não insere)
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
            // Procura se o DbContext já possui essa entidade rastreada em memória
            var local = _myDBContext.Set<TypeEntity>()
                                    .Local
                                    .FirstOrDefault(entry => entry.Id.Equals(entity.Id));

            // Se existir, remove o rastreamento antigo para dar lugar à nova alteração
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
