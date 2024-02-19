using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistem.Application.Dtos
{
    public class ProdutoDto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Tipo { get; set; } // Melhorar pra um Enum
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
    }
}
