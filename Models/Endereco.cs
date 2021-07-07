using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiClientNet.Models
{
    public class Endereco
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [JsonPropertyName("UF")]
        public string UF { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string tipo { get; set; }

        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public int ClienteId { get; set; }
    }
}
