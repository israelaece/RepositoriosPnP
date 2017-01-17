namespace RepositoriosPnP.Dominio
{
    public class Cliente
    {
        public Cliente(Empresa empresa)
        {
            this.Empresa = empresa;
            this.Ativo = true;
        }

        public virtual Empresa Empresa { get; protected set; }

        public virtual bool Ativo { get; set; }

        public virtual string Id { get; set; }

        protected Cliente() { }
    }
}