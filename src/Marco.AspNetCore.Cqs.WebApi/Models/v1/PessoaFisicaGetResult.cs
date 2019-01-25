using System;

namespace Marco.AspNetCore.Cqs.WebApi.Models.v1
{
    public class PessoaFisicaGetResult
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}