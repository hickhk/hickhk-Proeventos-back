using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Application.Dtos
{
    public class EventoDto
    {
         public int Id { get; set; }
        [Required, StringLength(100, MinimumLength = 5, ErrorMessage = "The fild {0} must be between 5 and 100 caracters!")]
        public string Local { get; set; }
        [Required]
        public string DataEvento { get; set; }
        [Required]
        public string Tema { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Display(Name = "Qtd de Pessoas")]
        [Required, Range(1, 10000, ErrorMessage = "The people range must be between 1 and 10000!")]
        public int QtdPessoas { get; set; }
        [Required]
        public string ImagemUrl { get; set; }
        public IEnumerable<LoteDto> Lotes { get; set; }
        public IEnumerable<RedeSocialDto> RedesSociais { get; set; }
        public IEnumerable<PalestranteEventoDto> PalestrantesEventos { get; set; }
    }
}