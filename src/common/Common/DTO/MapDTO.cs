namespace DTO.DTO
{
    public class MapDTO
    {
        public MapDTO()
        {
        }

        public MapDTO(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}