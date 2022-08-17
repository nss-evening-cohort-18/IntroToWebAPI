namespace IntroToWebAPI.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Size { get; set; }
        public List<string> Toppings { get; set; }
        public string CrustType { get; set; }
        public string Extras { get; set; }
    }
}
