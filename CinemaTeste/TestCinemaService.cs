using AutoMapper;
using CinemaDomain;
using CinemaRepository.Base;
using CinemaRepository.Context;
using CinemaService.Base;
using CinemaService.Validators;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaTeste
{
    [TestClass]
    public class TestCinemaService
    {
        private ServiceCollection services;

        public ServiceProvider ConfigureServices()
        {
            services = new ServiceCollection();

            var conStr = $"Host=localhost;Port=5432;Database=CinemaDB;Username=postgres;Password=ifsp;Include Error Detail=true"; services = new ServiceCollection();
            services.AddDbContext<MyDBContext>(options => options.UseNpgsql(conStr));
            services.AddScoped<IBaseRepository<Genero>, BaseRepository<Genero>>();
            services.AddScoped<IBaseService<Genero>, BaseService<Genero>>();
            services.AddSingleton(new MapperConfiguration(cfg => { cfg.CreateMap<Genero, Genero>(); }, NullLoggerFactory.Instance).CreateMapper());
            return services.BuildServiceProvider();
        }

        [TestMethod]
        public void TesteGeneroService()
        {
            var serviceProvider = ConfigureServices();
            var generoService = serviceProvider.GetService<IBaseService<Genero>>();
            var genero = new Genero { Id = 4, Nome = "Animação" };
            var result = generoService.Create<Genero, Genero, GeneroValidator>(genero);
        }
    }
}
