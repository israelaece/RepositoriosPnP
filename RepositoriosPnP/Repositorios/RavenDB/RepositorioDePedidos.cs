using Raven.Client;
using System.Linq;
using RepositoriosPnP.Dominio;
using RepositoriosPnP.Dominio.Repositorios;

namespace RepositoriosPnP.Repositorios.RavenDB
{
    public class RepositorioDePedidos : IRepositorioDePedidos
    {
        private readonly IDocumentSession session;

        public RepositorioDePedidos(IDocumentSession session)
        {
            this.session = session;
        }

        public void Salvar(Pedido entidade)
        {
            session.Store(entidade);
            session.SaveChanges();
        }

        public Pedido BuscarPor(string id)
        {
            return (from p in session.Query<Pedido>() where p.Id == id select p).SingleOrDefault();
        }
    }
}