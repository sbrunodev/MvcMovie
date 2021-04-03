using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class Paciente
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public string Localizacao { get; set; }

        [StringLength(200)]
        public string Observacao { get; set; }
        public int Ativo { get; set; }
    }
}