using Sprint0;

public interface IState
{
    void ChangeDirection(Player.Directions dir);
    void Update();
    void Attack();
    void UseItem(IProjectile proj) { return; }
}
