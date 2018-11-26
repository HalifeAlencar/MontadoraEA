using MontadoraEA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MontadoraEA.Repository
{
    public class UsuarioRepository
    {
        private readonly Contexto db = new Contexto();

        public void Adicionar(Usuario usuario)
        {
            db.Usuario.Add(usuario);
            db.SaveChanges();
        }

        public IEnumerable<Usuario> ListaUsuario()
        {
            return db.Usuario.ToList();
        }

        public Usuario BuscaUsuario(int? id)
        {
            return db.Usuario.Find(id);
        }

        public Usuario BuscaLogin(string login, string senha)
        {
            return db.Usuario.FirstOrDefault(x => x.Login.Equals(login) && x.Senha.Equals(senha));
        }
        public Usuario BuscaSenha(int senha)
        {
            return db.Usuario.Find(senha);
        }

        public void Editar(Usuario usuario)
        {
            db.Entry(usuario).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Excluir(Usuario usuario)
        {
            db.Usuario.Remove(usuario);
            db.SaveChanges();
        }       

    }
}