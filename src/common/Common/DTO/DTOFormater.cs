using System;

namespace DTO.DTO
{
    public static class DTOFormater
    {
        private static readonly DateTime ReferenceDate = new DateTime(1900,1,1);
        private const string Empty = "Vacío";
        private const string EmptyDate = "--/--/----";
        private const string EmptyDateTime = "--/--/---- --:--";

        public static string FormatDate(DateTime date)
        {
            return date < ReferenceDate ? EmptyDate : date.ToString("d");
        }

        public static string FormatDateTime(DateTime dateTime)
        {
            return dateTime < ReferenceDate ? EmptyDateTime : dateTime.ToString("g");
        }

        public static string FormatMoney(double money)
        {
            return $"$ {money:N2}";
        }

        public static string FormatNumber(int number)
        {
            return number.ToString("N0");
        }

        public static string FormatNumber(double number)
        {
            return number.ToString("N0");
        }

        public static string FormatPercent(double percent)
        {
            return percent.ToString("P2");
        }

        public static string FormatArray(MapDTO[] map)
        {
            if (map == null) return Empty;
            return map.Length == 0 ? Empty : string.Join(", ", Array.ConvertAll(map, m => m.Nombre));
        }

        public static string FormatProjectStatus(string status)
        {
            switch (status)
            {
                case "INCOMPLETO":
                    return "Datos Incompletos";
                case "EN_PROCESO":
                    return "Proyecto en Proceso";
                case "CANCELADO":
                    return "Proyecto Cancelado";
                case "FINALIZADO":
                    return "Proyecto Finalizado";
                case "VERIFICAR":
                    return "Enviado para verificación";
                case "PRE_VERIFICAR":
                    return "Pendiente de verificación";
                case "1REVISION":
                    return "Primera Revisión";
                case "2REVISION":
                    return "Segunda Revisión";
                case "3REVISION":
                    return "Tercera Revisión";
                default:
                    return "N/A";
            }
        }
    }
}