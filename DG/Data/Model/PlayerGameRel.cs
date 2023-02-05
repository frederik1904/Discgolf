namespace DG.Data.Model;

public class PlayerGameRel : Entity
{
    public virtual Player @Player { get; set; }
    public virtual Game @Game { get; set; }
}