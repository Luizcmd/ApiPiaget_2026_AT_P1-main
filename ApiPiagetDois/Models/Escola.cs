using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiPiagetDois.Models
{
    public class Escola : Base
    {
        [Required(ErrorMessage = "Informe o nome")]
        [JsonPropertyName("nome")]
        public string? EscolaNome { get; set; }

        [Required]
        [JsonPropertyName("telefone")]
        public string? EscolaTelefone { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Formato Email Invalido")]
        [JsonPropertyName("email")]
        public string? EscolaEmail { get; set; }
    }
}
