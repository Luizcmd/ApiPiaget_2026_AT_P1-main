using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiPiagetDois.Models
{
    public class Professor : Base
    {
        [Required(ErrorMessage = "Informe o nome")]
        [JsonPropertyName("nome")]
        public string? ProfessorNome { get; set; }

        [Required]
        [JsonPropertyName("telefone")]
        public string? ProfessorTelefone { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Formato Email Invalido")]
        [JsonPropertyName("email")]
        public string? ProfessorEmail { get; set; }

        [Required]
        [JsonPropertyName("disciplina")]
        public string? ProfessorDisciplina { get; set; }
    }
}
