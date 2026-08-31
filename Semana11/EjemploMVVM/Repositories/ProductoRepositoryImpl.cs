using EjemploMVVM.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;

namespace EjemploMVVM.Repositories
{
    public class ProductoRepositoryImpl : IProductoRepository
    {
        string cn = string.Empty;
        public ProductoRepositoryImpl()
        {
            cn = ConfigurationManager.ConnectionStrings["EjemploMVVM.Properties.Settings.NorthwindDB"].ConnectionString;
        }

        public List<Producto> BuscarPorNombre(string nombre)
        {
            using (SqlConnection conex = new SqlConnection(cn))
            {
                conex.Open();
                string query = "SELECT ProductID,ProductName,UnitPrice,Discontinued From Products WHERE (@Nombre IS NULL OR ProductName LIKE @Nombre)";
                SqlCommand command = new SqlCommand(query, conex);

                string? nombreParametro = string.IsNullOrEmpty(nombre) ? null : "%" + nombre + "%";

                command.Parameters.Add("@Nombre", SqlDbType.NVarChar, 40).Value = nombreParametro;

                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                List<Producto> listaProductos = new List<Producto>();
                while (reader.Read())
                {
                    Producto producto = new Producto
                    {
                        Id = reader.GetInt32(0),
                        nombre = reader.GetString(1),
                        precio = reader.GetDecimal(2),
                        discontinuado = reader.GetBoolean(3)
                    };
                    listaProductos.Add(producto);
                }
                return listaProductos;
            }
        }

        public List<Producto> ObtenerTodos()
        {
            

            using (SqlConnection conex = new SqlConnection(cn))
            {
                conex.Open();
                string query = "SELECT ProductID,ProductName,UnitPrice,Discontinued From Products";

                SqlCommand command = new SqlCommand(query, conex);

                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                List<Producto> listaProductos = new List<Producto>();
                while (reader.Read())
                {
                    Producto producto = new Producto
                    {
                        Id = reader.GetInt32(0),
                        nombre=reader.GetString(1),
                        precio = reader.GetDecimal(2),
                        discontinuado = reader.GetBoolean(3)
                    };
                    listaProductos.Add(producto);
                }
                return listaProductos;
            }
        }
    }
}
