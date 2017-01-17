using RepositoriosPnP.Dominio;
using RepositoriosPnP.Repositorios;
using RepositoriosPnP.Repositorios.RavenDB;

namespace RepositoriosPnP.Exemplos
{
    public static class Relacionamentos
    {
        public static void Executar()
        {
            //Flat();
            //PorId();
            //Redundante();
        }

        private static void Flat()
        {
            var repositorioDePedidos = new RepositorioDePedidos(RavenDBContext.Store.OpenSession());

            var produto = new Produto() { Descricao = "Mouse Microsoft", Valor = 120M };
            var pedido = new Pedido();

            pedido.AdicionarItem(new Pedido.Item(produto, 2));

            repositorioDePedidos.Salvar(pedido);
        }

        private static void PorId()
        {
            using (var session = RavenDBContext.Store.OpenSession())
            {
                var repositorioDePedidos = new RepositorioDePedidos(session);
                var repositorioDeProdutos = new RepositorioDeProdutos(session);

                var produto = new Produto() { Descricao = "Mouse Microsoft", Valor = 120M };

                repositorioDeProdutos.Salvar(produto);

                var pedido = new Pedido();

                pedido.AdicionarItem(new Pedido.Item(produto, 2));

                repositorioDePedidos.Salvar(pedido);
            }
        }

        private static void Redundante()
        {
            using (var session = RavenDBContext.Store.OpenSession())
            {
                var repositorioDePedidos = new RepositorioDePedidos(session);

                var produto = new Produto() { Descricao = "Mouse Microsoft", Valor = 120M };
                var pedido = new Pedido();

                pedido.AdicionarItem(new Pedido.Item(produto, 2));

                repositorioDePedidos.Salvar(pedido);
            }
        }
    }
}