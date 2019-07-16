using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Domain.DbHelper
{
    public class AudityEntity
    {
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        [ForeignKey("CreatedBy")]
        public Usuario CreatedUsuario { get; set; }

        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        [ForeignKey("UpdatedBy")]
        public Usuario UpdatedUsuario { get; set; }

        public DateTime? DeletedAt { get; set; }
        public string DeletedBy { get; set; }
        [ForeignKey("DeletedBy")]
        public Usuario DeletedUsuario { get; set; }
    }
}
