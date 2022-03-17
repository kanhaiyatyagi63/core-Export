namespace Export.Model
{
    public class FileInfoModel
    {
        public string? FileName { get; set; }
        public byte[]? Stream { get; set; }
        public string? ContentType { get; set; }
    }
}
