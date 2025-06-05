using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : Singleton<PlayerManager>
{
    [SerializeField] private int m_fullHealth = 100;
    [SerializeField] private int m_startingAmmo = 10;
    [SerializeField] private int m_startingScore = 0;
    private int _health;
    private int _ammo;
    private int _score;
    public event Action<int, int, int> OnHealthUpdated; //currHealth, FullHealth, DamageTaken
    public event Action<int> OnAmmoUpdated; //current ammo
    public event Action<int> OnScoreUpdated; //currScore

    private GameStateManager _gameStateManager;


    void Awake()
    {
        InitializeSingleton(this);
        _gameStateManager = ServiceLocator.instance.GetService<GameStateManager>();   
    }

    void Start()
    {
        _health = m_fullHealth;
        _ammo = m_startingAmmo;
        _score = m_startingScore;
        UpdateUI();
    }

    void UpdateUI()
    {
        OnHealthUpdated?.Invoke(_health, m_fullHealth, 0);
        OnScoreUpdated?.Invoke(_score);
        OnAmmoUpdated?.Invoke(_ammo);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            _health = 0;

            _gameStateManager.ChangeState(new DeadState(_gameStateManager));
            Debug.Log(_gameStateManager.CurrentStateName);
        }

        OnHealthUpdated?.Invoke(_health, m_fullHealth, damage);
    }

    public void AddScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        OnScoreUpdated?.Invoke(_score);
    }

    public void AddAmmo(int ammoToAdd)
    {
        _ammo += ammoToAdd;
        OnAmmoUpdated?.Invoke(_ammo);
    }

    public void Shoot(int ammoCost)
    {
        //TODO: Decide whether or not this behavior should be in here, or inside a "weapon manager" class.
        
    }
}
