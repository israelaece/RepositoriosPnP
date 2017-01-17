using System;
using RepositoriosPnP.Dominio;
using RepositoriosPnP.Repositorios;
using R = RepositoriosPnP.Repositorios;
using NHibernate.Tool.hbm2ddl;

namespace RepositoriosPnP.Exemplos
{
    public static class Repositorios
    {
        public static void Executar()
        {
            //ViaNHibernate();
            //ViaRavenDB();
        }

        private static void ViaNHibernate()
        {
            using (var session = NHibernateContext.Factory.OpenSession())
            {
                //Use para criar a base de dados de teste
                //new SchemaExport(config).Execute(false, true, false);

                var repositorio = new R.NHibernate.RepositorioDeClientes(session);
                var cliente = new Cliente(new Empresa() { RazaoSocial = "Nome Ltda", Cnpj = "123" });

                repositorio.Salvar(cliente);

                Console.WriteLine(repositorio.BuscarPor(cliente.Empresa.Cnpj).Empresa.RazaoSocial);
            }
        }

        private static void ViaRavenDB()
        {
            using (var session = RavenDBContext.Store.OpenSession())
            {
                var repositorio = new R.RavenDB.RepositorioDeClientes(session);
                var cliente = new Cliente(new Empresa() { RazaoSocial = "Nome Ltda", Cnpj = "123" });

                repositorio.Salvar(cliente);

                Console.WriteLine(repositorio.BuscarPor(cliente.Empresa.Cnpj).Empresa.RazaoSocial);
            }
        }
    }
}