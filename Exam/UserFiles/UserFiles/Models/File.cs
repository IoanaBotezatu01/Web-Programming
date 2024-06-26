namespace UserFiles.Models
{
    public class File
    {
        public int Id { get; set; } 
        public string UserId { get; set; }
        public string Filename { get; set; }
        public string Filepath { get; set; }
        public int Size { get; set; }
        public File() { }
    }
}
