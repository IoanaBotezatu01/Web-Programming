namespace ProjectAvatars.Models
{
    public class Log
    {
        public int Id { get; set; }
        public DateOnly Date {  get; set; }

        public string Text { get; set; }
        public Log() { }
    }
}
