namespace DTO.DTO
{
    public class ArchivoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Random { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public long Size { get; set; }
        public string Type { get; set; }
        public string FullName => Name + "." + Type;
    }
}