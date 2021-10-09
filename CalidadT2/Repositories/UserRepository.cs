using CalidadT2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalidadT2.Repositories
{
    public interface IUserrepository
    {
        public Usuario FindUserByNameAndPassword(string username, string password);
    }
    public class UserRepository : IUserrepository
    {
        private readonly AppBibliotecaContext context;
        public UserRepository(AppBibliotecaContext context)
        {
            this.context = context;
        }
        public Usuario FindUserByNameAndPassword(string username, string password)
        {
            return context.Usuarios.Where(o => o.Username == username && o.Password == password).FirstOrDefault();
        }
    }
}
