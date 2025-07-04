using UnityEngine;

public class Dummy : MonoBehaviour, IEnemy
{

    private int m_health = 2;
    public void Alert()
    {
        throw new System.NotImplementedException();
    }

    public void GetShot(int dmg)
    {
        m_health -= dmg;

        if (m_health <= 0)
        {
            ServiceLocator.instance.GetService<EnemyManager>().RemoveEnemyToRange(this);
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
