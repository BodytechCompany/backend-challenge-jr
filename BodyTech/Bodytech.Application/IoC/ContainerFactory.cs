using Autofac;
using Autofac.Core;
using Autofac.Integration.WebApi;
using Bodytech.Application.Repository;
using Bodytech.Application.Repository.Excercicio;
using Bodytech.Application.Repository.Roles;
using Bodytech.Application.Repository.Usuario;
using Bodytech.Application.Services.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace Bodytech.Application.IoC
{
    public static class ContainerFactory
    {
        public static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;

            //registro dos nossos IoC types
            builder.RegisterType<BodyTechContext>().AsSelf();
            builder.RegisterType<UsuarioRepository>().As<IUsuarioRepository>().InstancePerLifetimeScope();
            builder.RegisterType<RolesRepository>().As<IRolesRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ExercicioRepository>().As<IExercicioRepository>().InstancePerLifetimeScope();
            builder.RegisterType<JwtService>().As<IJwtService>().InstancePerLifetimeScope();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);
            builder.RegisterWebApiModelBinderProvider();

            var container = builder.Build();
            return container;
        }
    }
}