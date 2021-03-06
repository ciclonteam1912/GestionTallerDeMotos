﻿using GestionTallerDeMotos.Models.ModelosDeDominio;
using System;
using System.ComponentModel.DataAnnotations;

namespace GestionTallerDeMotos.ViewModels
{
    public class TalonarioViewModel
    {
        public int Id { get; set; }

        [Required]
        public int? Timbrado { get; set; }

        [Required]
        [Display(Name = "Fecha de Inicio de Vigencia")]
        public DateTime? FechaInicioVigencia { get; set; }

        [Required]
        [Display(Name = "Fecha Fin de Vigencia")]
        public DateTime? FechaFinVigencia { get; set; }

        [Required]
        [Display(Name = "Número de Factura Inicial")]
        public int? NumeroFacturaInicial { get; set; }

        [Required]
        [Display(Name = "Número de Factura Final")]
        public int? NumeroFacturaFinal { get; set; }

        [Required]
        [Display(Name = "Número de Factura Actual")]
        public int? NumeroFacturaActual { get; set; }

        public string Titulo
        {
            get
            {
                return Id != 0 ? "Editar Talonario" : "Agregar Talonario";
            }
        }

        public TalonarioViewModel()
        {

        }

        public TalonarioViewModel(Talonario talonario)
        {
            Id = talonario.Id;
            Timbrado = talonario.Timbrado;
            FechaInicioVigencia = talonario.FechaInicioVigencia;
            FechaFinVigencia = talonario.FechaFinVigencia;
            NumeroFacturaInicial = talonario.NumeroFacturaInicial;
            NumeroFacturaFinal = talonario.NumeroFacturaFinal;
            NumeroFacturaActual = talonario.NumeroFacturaActual;
        }
    }
}