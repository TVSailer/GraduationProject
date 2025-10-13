public class Club
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string Leader { get; set; }
    public string Schedule { get; set; }
    public string Location { get; set; }
    public int MaxParticipants { get; set; }
    public int CurrentParticipants { get; set; }
    public double Rating { get; set; }
    public int ReviewCount { get; set; }
    public List<Review> Reviews { get; set; } = new List<Review>();
}
