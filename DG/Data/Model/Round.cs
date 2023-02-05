namespace DG.Data.Model;

public class Round : Entity
{
    public virtual Player @Player { get; set; }
    public virtual Game @Game { get; set; }
    public int HoleNr { get; set; }
    public int Trows { get; set; }
}