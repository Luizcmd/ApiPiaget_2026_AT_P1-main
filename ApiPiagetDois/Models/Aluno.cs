using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiPiagetDois.Models
{
    /// <summary>
    /// Classe aluno
    /// </summary>
    public class Aluno : Base
    {
        [Required(ErrorMessage = "Informe o nome")]
        [JsonPropertyName("nome")]
        public string? AlunoNome { get; set; }

        [Required]
        [JsonPropertyName("telefone")]
        public string? AlunoTelefone { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Formato Email Invalido")]
        [JsonPropertyName("email")]
        public string? AlunoEmail { get; set; }

        [Required]
        [JsonPropertyName("matricula")]
        public string? AlunoMatricula { get; set; }
    }
}
