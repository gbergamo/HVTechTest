namespace Orders.Model
{
    public class Foods
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Enums.TimeOfDayEnum TimeOfDay { get; set; }
    }
}
