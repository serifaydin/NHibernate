using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Panel.NHibernateMapping;

namespace Panel.NHibernateDB
{
    public class NHibernateSQLContext
    {
        private static ISessionFactory session;

        private static ISessionFactory CreateSession()
        {
            if (session != null)
                return session;

            FluentConfiguration _config = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(
                                   x => x.Server(@"DESKTOP-0LVNBU7\SERIFSQL").
                                        Username("sa").
                                        Password("123").
                                        Database("NHibernateDB")))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserExperienceMapping>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserMapping>())
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true));

            session = _config.BuildSessionFactory();
            return session;
        }

        public static ISession SessionOpen()
        {
            return CreateSession().OpenSession();
        }
    }
}