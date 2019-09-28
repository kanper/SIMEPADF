using System;
using Model.Domain.DbHelper;

namespace Model.Domain
{
    public class RegistroRevision: AudityEntity, ISoftDeleted
    {
        public RegistroRevision()
        {
        }

        public RegistroRevision(string numeroRevision, string trimestre)
        {
            NumeroRevision = numeroRevision;
            Trimestre = trimestre;
            Revisado = false;
            RevisionCompleta = false;
        }

        public int RegistroRevisionId { get; set; }
        public DateTime FechaRevisado { get; set; }
        public bool RevisionCompleta { get; set; }
        public string NumeroRevision { get; set; }        
        public string Trimestre { get; set; }
        public bool Revisado {get; set;}                      
        public ProyectoPais ProyectoPais { get; set; }
        public bool Deleted { get; set; }
    }
}