using UnityEngine;

public class AmmoPickup : MonoBehaviour
{

    private PlayerManager _playerManager;
    [SerializeField] private int m_ammoAmount = 1;

    void Awake()
    {
        _playerManager = ServiceLocator.instance.GetService<PlayerManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _playerManager.AddAmmo(m_ammoAmount);
            Debug.Log("Ammo Picked up!");
            Destroy(gameObject);
            
        }
    }
}
