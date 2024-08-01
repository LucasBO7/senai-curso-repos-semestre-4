using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleInventario
{
    public class Produto(string nome, int quantidade)
    {
        public string? Nome { get; set; } = nome;
        public int Quantidade { get; set; } = quantidade;
    }
}