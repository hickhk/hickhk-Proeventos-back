using ProEventos.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Application.Dtos
{
    public class PalestranteDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The fild {0} is required!")]
        public string Nome { get; set; }
        public string MiniCurriculo { get; set; }

        [Required, RegularExpression("([^\\s]+(\\.(?i)(jpe?g|png|gif|bmp))$)", ErrorMessage = "The fild {0} must be a valid image!")]
        public string Foto { get; set; }

        [Required, Phone(ErrorMessage = "The fild {0} must be a valid number!")]
        public string Telefone { get; set; }

        [Display(Name = "e-mail")]
        [Required(ErrorMessage = "The fild {0} is required!"), EmailAddress(ErrorMessage = "The adress in fild {0} is inválid!")]
        public string Email { get; set; }
        //public IEnumerable<RedeSocial> RedesSociais { get; set; }
        //public IEnumerable<PalestranteEvento> PalestrantesEventos { get; set; }
    }
}
