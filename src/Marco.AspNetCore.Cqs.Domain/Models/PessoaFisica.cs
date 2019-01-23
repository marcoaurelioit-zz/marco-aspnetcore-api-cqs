using Marco.Domain.Core.Models;
using System;

namespace Marco.AspNetCore.Cqs.Domain.Models
{
    public class PessoaFisica : Entity
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}