using System;
using Model.Domain.DbHelper;

namespace Model.Domain
{
    public class RegistroRevision: AudityEntity, ISoftDeleted
    {
        public RegistroRevision()
        {
        }

        public RegistroRevision(int numeroRevision, int trimestre)
        {
            NumeroRevision = numeroRevision;
            Trimestre = trimestre;
            Revisado = false;
            RevisionCompleta = false;
            Retornado = false;
        }

        public int RegistroRevisionId { get; set; }
        public DateTime FechaRevisado { get; set; }
        public bool RevisionCompleta { get; set; }
        public int NumeroRevision { get; set; }        
        public int Trimestre { get; set; }
        public bool Revisado {get; set;}
        public string Comentario { get; set; }
        public bool Retornado { get; set; }
        public ProyectoPais ProyectoPais { get; set; }
        public bool Deleted { get; set; }
    }
}