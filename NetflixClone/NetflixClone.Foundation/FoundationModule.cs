using Autofac;
using NetflixClone.Foundation.Entities;
using NetflixClone.Foundation.Repositories;
using NetflixClone.Foundation.Services;
using System;

namespace NetflixClone.Foundation
{
    public class FoundationModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public FoundationModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<VideoService>().As<IVideoService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<CategoryService>().As<ICategoryService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<SubscriptionTypeService>().As<ISubscriptionTypeService>()
               .InstancePerLifetimeScope();

            builder.RegisterType<Repository<Video, Guid>>().As<IRepository<Video, Guid>>()
                .InstancePerLifetimeScope();
            builder.RegisterType<Repository<VideoCategory, int>>().As<IRepository<VideoCategory, int>>()
                .InstancePerLifetimeScope();
            builder.RegisterType<Repository<SubscriptionType, int>>().As<IRepository<SubscriptionType, int>>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
