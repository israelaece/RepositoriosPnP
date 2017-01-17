using Raven.Client;
using System.Linq;
using RepositoriosPnP.Dominio;
using RepositoriosPnP.Dominio.Repositorios;

namespace RepositoriosPnP.Repositorios.RavenDB
{
    public class RepositorioDeClientes : IRepositorioDeClientes
    {
        private readonly IDocumentSession session;

        public RepositorioDeClientes(IDocumentSession session)
        {
            this.session = session;
        }

        public void Salvar(Cliente entidade)
        {
            session.Store(entidade);
            session.SaveChanges();
        }

        public Cliente BuscarPor(string cnpj)
        {
            return
                (
                    from c in session.Query<Cliente>()
                    where c.Empresa.Cnpj == cnpj
                    select c
                ).SingleOrDefault();
        }
    }
}