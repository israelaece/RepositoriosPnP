using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriosPnP.Dominio
{
    public class Pedido
    {
        private readonly IList<Item> itens = new List<Item>();

        public Pedido()
        {
            this.Data = DateTime.Now;
        }

        public DateTime Data { get; set; }

        public decimal Total { get; set; }

        public string Id { get; set; }

        public void AdicionarItem(Item item)
        {
            this.itens.Add(item);
            this.Total += item.Total;
        }

        public IEnumerable<Item> Itens
        {
            get
            {
                return this.itens;
            }
        }

        //FLAT
        //public class Item
        //{
        //    public Item(Produto produto, int quantidade)
        //    {
        //        this.Produto = produto;
        //        this.Quantidade = quantidade;
        //        this.Total = produto.Valor * quantidade;
        //    }

        //    public Produto Produto { get; private set; }

        //    public int Quantidade { get; private set; }

        //    public decimal Total { get; private set; }
        //}

        //POR-ID
        //public class Item
        //{
        //    public Item(Produto produto, int quantidade)
        //    {
        //        this.ProdutoId = produto.Id;
        //        this.Quantidade = quantidade;
        //        this.Total = produto.Valor * quantidade;
        //    }

        //    public string ProdutoId { get; private set; }

        //    public int Quantidade { get; private set; }

        //    public decimal Total { get; private set; }
        //}

        //REDUNDANTE
        public class Item
        {
            public Item(Produto produto, int quantidade)
            {
                this.Descricao = produto.Descricao;
                this.Quantidade = quantidade;
                this.Total = produto.Valor * quantidade;
            }

            public string Descricao { get; private set; }

            public int Quantidade { get; private set; }

            public decimal Total { get; private set; }
        }
    }
}