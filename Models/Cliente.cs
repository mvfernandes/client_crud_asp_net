using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiClientNet.Models
{
    public class Cliente
    {
        public Cliente()
        {
            Enderecos = new List<Endereco>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [JsonPropertyName("data_nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Sexo { get; set; }

        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}
