using PracticalChallenge.Business.Mensagens;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PracticalChallenge.Api.EntidadesDto
{
    public class ProdutoDto
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Quantidade { get; set; }
        [Required]
        [RegularExpression(@"^-?[0-9][0-9,\.]+$", ErrorMessage = MensagensValidacao.ME003)]
        public decimal ValorUnitario { get; set; }
    }
}
