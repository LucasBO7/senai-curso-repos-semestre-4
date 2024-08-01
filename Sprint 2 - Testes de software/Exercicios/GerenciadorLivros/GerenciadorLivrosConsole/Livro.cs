using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorLivros
{
    public class Livro
    {
        public string? Titulo { get; set; }
        public string? Autoria { get; set; }

        public static void AdicionarLivro(List<Livro> livros, Livro newLivro)
        {
            livros.Add(newLivro);
        }
    }
}