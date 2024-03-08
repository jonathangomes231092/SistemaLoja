﻿namespace Sistem.Infra.Data.SqlServer.Models
{
    public class ProdutoModel
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Tipo { get; set; } // Melhorar pra um Enum
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
    }
}
