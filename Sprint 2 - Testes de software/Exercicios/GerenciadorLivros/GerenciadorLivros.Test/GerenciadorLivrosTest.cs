using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorLivros.Test
{
    public class GerenciadorLivrosTest
    {
        // Princípio AAA: Act, Arrange e Assert
        // Princípio AAA: Agir, Organizar e Provar
        [Fact]
        public void AdicionarLivroEmLista()
        {
            // Dados - Organizar
            List<Livro> listaLivros = [];
            Livro novoLivro = new()
            {
                Titulo = "A dança do universo",
                Autoria = "Stephen Hawking"
            };

            // Rodar função - Agir
            Livro.AdicionarLivro(listaLivros, novoLivro);

            // Testar função - Provar
            Assert.Contains(novoLivro, listaLivros);
        }
    }
}