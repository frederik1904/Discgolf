namespace DG.Data.Model;

public class Game  : Entity
{
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public virtual Course @Course { get; set; }

}