using Raven.Client;
using System.Linq;
using RepositoriosPnP.Dominio;
using RepositoriosPnP.Dominio.Repositorios;

namespace RepositoriosPnP.Repositorios.RavenDB
{
    public class RepositorioDeProdutos : IRepositorioDeProdutos
    {
        private readonly IDocumentSession session;

        public RepositorioDeProdutos(IDocumentSession session)
        {
            this.session = session;
        }

        public void Salvar(Produto entidade)
        {
            session.Store(entidade);
            session.SaveChanges();
        }

        public Produto BuscarPor(string id)
        {
            return (from p in session.Query<Produto>() where p.Id == id select p).SingleOrDefault();
        }
    }
}