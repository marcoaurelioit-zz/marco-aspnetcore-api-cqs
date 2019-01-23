using System.ComponentModel.DataAnnotations;

namespace Marco.AspNetCore.Cqs.Infra.Data.Dapper
{
    public class SqlServerReadOnlySettings
    {
        [Required]
        public string DefaultConnection { get; set; }
    }
}