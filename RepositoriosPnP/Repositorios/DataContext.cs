using NHibernate;
using NHibernate.Cfg;
using Raven.Client;
using Raven.Client.Document;
using System;
using System.Reflection;

namespace RepositoriosPnP.Repositorios
{
    public static class NHibernateContext
    {
        private static readonly Lazy<ISessionFactory> factory;

        static NHibernateContext()
        {
            factory =
                new Lazy<ISessionFactory>(() =>
                    new Configuration().Configure().AddAssembly(Assembly.GetExecutingAssembly()).BuildSessionFactory());
        }

        public static ISessionFactory Factory
        {
            get
            {
                return factory.Value;
            }
        }
    }

    public static class RavenDBContext
    {
        private static readonly Lazy<IDocumentStore> store;

        static RavenDBContext()
        {
            store =
                new Lazy<IDocumentStore>(() => new DocumentStore { ConnectionStringName = "RavenDB" }.Initialize());
        }

        public static IDocumentStore Store
        {
            get
            {
                return store.Value;
            }
        }
    }
}