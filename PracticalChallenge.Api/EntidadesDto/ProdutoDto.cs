using Newtonsoft.Json;
using PracticalChallenge.Business.Mensagens;
using System;
using System.ComponentModel.DataAnnotations;

namespace PracticalChallenge.Api.EntidadesDto
{
    public class ProdutoDto
    {
        [Key]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Quantidade { get; set; }
        [Required]
        public decimal ValorUnitario { get; set; }
    }
}
