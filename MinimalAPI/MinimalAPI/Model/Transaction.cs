namespace MinimalAPI.Model
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly date { get; set; }
        public float money { get; set; }
    }
}
