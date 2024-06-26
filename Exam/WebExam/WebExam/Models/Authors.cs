namespace WebExam.Models
{
    public class Authors
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DocumentList { get; set; }
        public string MovieList { get; set; }
        public Authors() { }
        public Authors(int id, string name, string documentList, string movieList)
        {
            Id = id;
            Name = name;
            DocumentList = documentList;
            MovieList = movieList;
        }
    }
}
