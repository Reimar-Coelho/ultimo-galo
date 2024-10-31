using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float _currentHealth;
    [SerializeField]
    private float _maximumHealth;
    [SerializeField]
    FloatingHealthBar _healthBar;

    private void Awake()
    {
        _healthBar = GetComponentInChildren<FloatingHealthBar>();
    }

    private void Start()
    {
        _healthBar.UpdateHealthBar(_currentHealth, _maximumHealth);
    }

    public float RemainingHealthPercentage
    {
        get
        {
            return _currentHealth / _maximumHealth;
        }
    }

    public void TakeDamage(float damageAmount)
    {
        if (_currentHealth == 0)
        {
            return;
        }
        _currentHealth -= damageAmount;
        _healthBar.UpdateHealthBar(_currentHealth, _maximumHealth);
        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }
    }

    public void AddHealth(float amountToAdd)
    {
        if (_currentHealth ==_maximumHealth)
        {
            return;
        }

        _currentHealth += amountToAdd;

        if (_currentHealth > _maximumHealth)
        {
            _currentHealth=_maximumHealth;
        }
    }
}
