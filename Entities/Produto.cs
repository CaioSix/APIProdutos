using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Produtos.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Valor { get; set; }
    }
}