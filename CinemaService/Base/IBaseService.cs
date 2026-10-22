using CinemaDomain.Base;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaService.Base
{
    public interface IBaseService<TypeEntity> where TypeEntity : IBaseEntity
    {
        TypeOutputModel Create<TypeInputModel, 
                               TypeOutputModel,
                               TypeValidator>(TypeValidator entity) 
            where TypeInputModel : class 
            where TypeOutputModel : class 
            where TypeValidator : AbstractValidator<TypeEntity>;
    }
}
