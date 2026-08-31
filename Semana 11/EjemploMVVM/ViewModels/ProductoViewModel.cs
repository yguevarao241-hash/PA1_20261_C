using EjemploMVVM.Commands;
using EjemploMVVM.Models;
using EjemploMVVM.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EjemploMVVM.ViewModels
{
    public class ProductoViewModel
    {
        public ObservableCollection<Producto> productos { set; get; } = new ObservableCollection<Producto>();
        public RelayCommand CargarProductosCommand { get; set; }
        public string textoBuscar { get; set; } = string.Empty;

        private IProductoRepository _repository;
        public ProductoViewModel()
        {
            _repository = new ProductoRepositoryImpl();
            CargarProductosCommand = new RelayCommand(BuscarProductos);

            CargarProductos();
        }

        private void BuscarProductos()
        {
            List<Producto> lista = _repository.BuscarPorNombre(textoBuscar);
            productos.Clear();
            foreach (Producto producto in lista)
            {
                productos.Add(producto);
            }
        }

        private void CargarProductos()
        {
            List<Producto> lista = _repository.ObtenerTodos();
            productos.Clear();
            foreach (Producto producto in lista)
            {
                productos.Add(producto);
            }
        }

    }
}