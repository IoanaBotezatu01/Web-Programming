namespace Subiect922.Models
{
    public class Reservations
    {
        public int Id { get; set; }
        public string Person { get; set; }
        public string ReservationType { get; set; }
        public int IdReservedResource {  get; set; }
        public Reservations() { }

    }
}
