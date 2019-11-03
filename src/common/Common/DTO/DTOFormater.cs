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
    }
}