using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class Protocolo
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int CodigoPaciente { get; set; }
        public virtual Paciente Paciente { get; set; }
        public List<Tarefa> ListaTarefas { get; set; }

    }
}
