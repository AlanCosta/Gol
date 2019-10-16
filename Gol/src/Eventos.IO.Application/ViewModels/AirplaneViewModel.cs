using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Gol.IO.Application.ViewModels
{
    public class AirplaneViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "CodigoAviao é requerido!")]
        [Display(Name = "Codigo do Aviao")]
        public string CodigoAviao { get; set; }
        [Required(ErrorMessage = "O Modelo é requerido!")]
        [Display(Name = "Modelo")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "QtdPassageiros é requerido!")]
        [Display(Name = "Quantidade de Passageiros")]
        public int QtdPassageiros { get; set; }
        public DateTime DataRegistro { get; set; }
    }
}
