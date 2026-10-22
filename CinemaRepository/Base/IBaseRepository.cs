using CinemaDomain.Base;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.ExpressionTranslators.Internal;
using System;
using System.Collections.Generic;
using System.Text;

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
