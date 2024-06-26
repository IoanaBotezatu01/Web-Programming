namespace WebExam.Models
{
    public class Documents
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Contents { get; set; }
        public Documents() { }
        public Documents(string id,string name, string contents)
        {
            Id = id;
            Name = name;
            Contents = contents;
        }
    }
}
