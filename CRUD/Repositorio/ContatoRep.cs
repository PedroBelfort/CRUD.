using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class ContatoRep : DbContext
    {
        public ContatoRep()
        {

        }

        public DbSet<Contato> Contatos { get; set; }


        public void Salvar (Contato contato)
        {
            Contatos.Add(contato);
            SaveChanges();
        }

        public IEnumerable Listar()
        {
            return Contatos.ToList();
        }

        public void Alterar(Contato contato)
        {
            var alterar = Contatos.Where(x => x.Id == contato.Id).ToList().FirstOrDefault();
            alterar.Nome = contato.Nome;
            alterar.Numero = contato.Numero;
            alterar.Endereco = contato.Endereco;
            SaveChanges();
        }

        public void Remover (Contato contato)
        {
            var remover = Contatos.Where(x => x.Id == contato.Id).ToList().FirstOrDefault();
            Set<Contato>().Remove(remover);

            SaveChanges();
        }
        public Contato Buscar (int id)
        {
            return Contatos.Where(x => x.Id == id).ToList().FirstOrDefault();

        }


    }
}
