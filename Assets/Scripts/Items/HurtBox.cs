using UnityEngine;

public class HurtBox : MonoBehaviour
{
    private PlayerManager _playerManager;
    [SerializeField] private int m_hurtAmount = 1;

    void Awake()
    {
        _playerManager = ServiceLocator.instance.GetService<PlayerManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _playerManager.TakeDamage(m_hurtAmount);
            Debug.Log("Got Hurt!");  
        }
    }

}
