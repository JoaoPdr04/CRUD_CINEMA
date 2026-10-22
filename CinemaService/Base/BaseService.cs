using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CinemaRepository.Base;
using CinemaDomain.Base;
using FluentValidation;
using Microsoft.IdentityModel.Tokens.Experimental;

namespace CinemaService.Base
{
    public class BaseService<TypeEntity> : IBaseService<TypeEntity> where TypeEntity : IBaseEntity
    {
        private readonly IBaseRepository<TypeEntity> _baseRepository;
        private readonly IMapper _mapper;

        public BaseService(IBaseRepository<TypeEntity> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public void Validated (TypeEntity obj, AbstractValidator<TypeEntity> validator)
        {
            validator.ValidateAndThrow(obj);
        }

        public TypeOutputModel Create<TypeInputModel, TypeOutputModel, TypeValidator>(TypeValidator entity)
            where TypeInputModel : class
            where TypeOutputModel : class
            where TypeValidator : AbstractValidator<TypeEntity>
        {
            var e = _mapper.Map<TypeEntity>(entity);
            Validated(e, Activator.CreateInstance<TypeValidator>());
            _baseRepository.Create(e);
            var outputModel = _mapper.Map<TypeOutputModel>(e);
            return outputModel;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TypeOutputModel> ReadAll<TypeOutputModel>() where TypeOutputModel : class
        {
            throw new NotImplementedException();
        }

        public TypeOutputModel ReadbyId<TypeOutputModel>(int id) where TypeOutputModel : class
        {
            throw new NotImplementedException();
        }

        public TypeOutputModel Update<TypeInputModel, TypeOutputModel, TypeValidator>(TypeValidator entity)
            where TypeInputModel : class
            where TypeOutputModel : class
            where TypeValidator : AbstractValidator<TypeEntity>
        {
            throw new NotImplementedException();
        }
    }
}