using System;

namespace RepositoriosPnP.Dominio.Repositorios
{
    public interface IRepositorio<T> where T : class
    {
        void Salvar(T entidade);

        T BuscarPor(string id);
    }
}