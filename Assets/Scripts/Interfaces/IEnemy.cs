using UnityEngine;

public interface IEnemy
{
    public void GetShot(int dmg);
    public void Alert();

    public Transform transform { get; }

}
