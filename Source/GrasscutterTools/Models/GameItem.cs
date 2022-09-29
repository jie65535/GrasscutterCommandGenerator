namespace GrasscutterTools.Models
{
    public class GameItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public override string ToString()
        {
            return $"{Id} : {Name}";
        }
    }
}
