using System;
using System.Collections.Generic;
using System.Text;

namespace EjemploMVVM.Repositories
{
    internal interface IAuthRepository
    {

        public bool ValidarUsuario(string username, string password);
    }
}
