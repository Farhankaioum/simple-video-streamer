using Autofac;
using NetflixClone.Web.Helpers;
using NetflixClone.Web.Models;

namespace NetflixClone.Web
{
    public class WebModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public WebModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ErrorViewModel>().AsSelf();
            builder.RegisterType<FileUploadHelper>().As<IFileUploadHelper>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
