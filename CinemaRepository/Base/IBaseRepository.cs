using CinemaDomain.Base;

namespace CinemaRepository.Base
{
    public interface IBaseRepository<TypeEntity> where TypeEntity : IBaseEntity
    {
        // Métodos do CRUD
        void Create(TypeEntity entity);
        TypeEntity ReadbyId(int id);
        IList<TypeEntity> ReadAll();
        void Delete(int entity);
        void Update(TypeEntity entity);
    }
}
