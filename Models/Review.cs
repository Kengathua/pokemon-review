namespace PokemonWebAPI.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Text { get; set; } = "";
        public int Rating { get; set;} = 0;
        public Reviewer Reviewer { get; set; } = new Reviewer();
        public Pokemon Pokemon { get; set; } = new Pokemon();
    }
}