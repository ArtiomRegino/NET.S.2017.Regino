namespace ORM.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public byte[] SmallImage { get; set; }
        public byte[] BigImage { get; set; }
        public string MimeType { get; set; }
        public string Description { get; set; }
    }
}
