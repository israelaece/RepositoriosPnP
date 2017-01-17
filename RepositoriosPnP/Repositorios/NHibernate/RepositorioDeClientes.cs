using NHibernate;
using NHibernate.Linq;
using System.Linq;
using RepositoriosPnP.Dominio;
using RepositoriosPnP.Dominio.Repositorios;

namespace RepositoriosPnP.Repositorios.NHibernate
{
    public class RepositorioDeClientes : IRepositorioDeClientes
    {
        private readonly ISession session;

        public RepositorioDeClientes(ISession session)
        {
            this.session = session;
        }

        public void Salvar(Cliente entidade)
        {
            session.Save(entidade);
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