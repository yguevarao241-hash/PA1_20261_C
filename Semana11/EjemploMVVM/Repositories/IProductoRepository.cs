using System;
using System.Collections.Generic;
using System.Text;
using EjemploMVVM.Models;

namespace EjemploMVVM.Repositories
{
    public interface IProductoRepository
    {
        public List<Producto> ObtenerTodos();
        public List<Producto> BuscarPorNombre(string nombre);
    }
}
