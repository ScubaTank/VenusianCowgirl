using System;
using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    private PlayerManager _playerManager;

    [Header("HUD Elements")]
    [SerializeField] private TMP_Text m_healthText;
    [SerializeField] private TMP_Text m_ammoText;
    [SerializeField] private TMP_Text m_scoreText;

    void Awake()
    {
        _playerManager = ServiceLocator.instance.GetService<PlayerManager>();
    }

    void OnEnable()
    {
        _playerManager.OnHealthUpdated += OnHealthUpdated;
        _playerManager.OnAmmoUpdated += OnAmmoUpdated;
        _playerManager.OnScoreUpdated += OnScoreUpdated;

    }

    void OnDisable()
    {
        _playerManager.OnHealthUpdated -= OnHealthUpdated;
        _playerManager.OnAmmoUpdated -= OnAmmoUpdated;
        _playerManager.OnScoreUpdated -= OnScoreUpdated;
    }

    private void OnHealthUpdated(int currHealth, int fullHealth, int dmgTaken)
    {
        //TODO: Cool little bubble hud or something for health... number will do for now.
        if (currHealth > 0)
        {
            m_healthText.text = currHealth.ToString();
        }
        else
        {
            m_healthText.text = "DEAD";
        }

    }

    private void OnAmmoUpdated(int currAmmo)
    {
        m_ammoText.text = currAmmo.ToString();
    }
    
        private void OnScoreUpdated(int currScore)
    {
        m_scoreText.text = currScore.ToString();
    }

}
