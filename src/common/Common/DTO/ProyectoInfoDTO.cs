using System;

namespace DTO.DTO
{
    public class ProyectoInfoDTO
    {
        private int numeroProductos;
        public int CodigoActividad { get; set; }        
        public string NombreActividad { get; set; }       
        public double Monto { get; set; }
        public DateTime FechaLimite { get; set; }

        public MapDTO[] Productos { get; set; }

        public int NumeroProductos
        {
            get => Productos.Length;
            set => numeroProductos = value;
        }    
    }
}