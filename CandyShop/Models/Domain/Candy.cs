namespace CandyShop.Models.Domain
{
    public class Candy
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public DateTime addDate { get; set;}
    }
}
