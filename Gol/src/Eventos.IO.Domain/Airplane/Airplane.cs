using Gol.IO.Domain.Core.Models;
using FluentValidation;
using System;

namespace Gol.IO.Domain.Airplane
{
    public class Airplane : Entity<Airplane>
    {
        public Airplane(int id, string codigoAviao, string modelo, int qtdPassageiros, DateTime dataRegistro)
        {
            Id = id;
            CodigoAviao = codigoAviao;
            Modelo = modelo;
            QtdPassageiros = qtdPassageiros;
            DataRegistro = dataRegistro;
        }

        private Airplane()
        {

        }
        public int Id { get; set; }
        public string CodigoAviao { get; protected set; }
        public string Modelo { get; protected set; }
        public int QtdPassageiros { get; protected set; }
        public DateTime DataRegistro { get; protected set; }

        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validações

        private void Validar()
        {
            ValidarCodigoAviao();
            ValidarModelo();
            ValidarQtdPassageiros();
            ValidationResult = Validate(this);
        }

        private void ValidarCodigoAviao()
        {
            RuleFor(c => c.CodigoAviao)
               .NotEmpty().WithMessage("CodigoAviao precisa ser preenchida!");
        }

        private void ValidarModelo()
        {
            RuleFor(c => c.Modelo)
               .NotEmpty().WithMessage("O Modelo precisa ser preenchido!");
        }

        private void ValidarQtdPassageiros()
        {
            RuleFor(c => c.QtdPassageiros)
               .NotEmpty().WithMessage("A Quantidade de Passageiros precisa ser preenchida!");
        }

        

        #endregion


        public static class AirplaneFactory
        {
            public static Airplane NovoAirplaneCompleto(int id, string codigoAviao, string modelo, int qtdPassageiros, DateTime dataRegistro)
            {
                var Airplane = new Airplane()
                {
                    Id = id,
                    CodigoAviao = codigoAviao,
                    Modelo = modelo,
                    QtdPassageiros = qtdPassageiros,
                    DataRegistro = dataRegistro
                };

                return Airplane;
            }
        }
    }
}
