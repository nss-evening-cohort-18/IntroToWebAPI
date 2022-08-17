namespace IntroToWebAPI.Models;

//Models are classes that represent things
//in your application/domain (domain = real-world business words)
public class Pizza
{
    public int Id { get; set; }
    public string Size { get; set; }
    public List<string> Toppings { get; set; }
    public string CrustType { get; set; }
    public string Extras { get; set; }
}
