using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<IEnemy> enemiesInTrigger = new List<IEnemy>();

    public void AddEnemyToRange(IEnemy enemy)
    {
        enemiesInTrigger.Add(enemy);
    }

    public void RemoveEnemyToRange(IEnemy enemy)
    {
        enemiesInTrigger.Remove(enemy);
    }
}
