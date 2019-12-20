using System;

namespace DTO.DTO
{
    public class AuditoriaDTO
    {
        public AuditoriaDTO(string @by, string action, string table, string identity, DateTime dateTime)
        {
            By = @by;
            Action = action;
            Table = table;
            Identity = identity;
            DateTime = dateTime;
        }

        public string By { get; set; }
        public string Action { get; set; }
        public string Table { get; set; }
        public string Identity { get; set; }
        public DateTime DateTime { get; set; }
        public string Summary => $"{Action} del registro {Table} con identificador \" {Identity} \"";
        public string AuditAt => DTOFormater.FormatDateTime(DateTime);
        public string ByUser => By ?? "N/A";
    }
}