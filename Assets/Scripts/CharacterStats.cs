using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour, iSaveable
{
    public int health;
    public int maxHealth;

    [SerializeField] protected bool isDead;

    private void Start()
    {
        InitVariables();
    }

    public virtual void CheckHealth()
    {
        if(health <= 0)
        {
            health = 0;
            Die();
        }
        
        if(health >= maxHealth)
        {
            health = maxHealth;
        }
    }

    public virtual void Die()
    {
        isDead = true;
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void SetHealthTo(int healthToSetTo)
    {
        health = healthToSetTo;
        CheckHealth();
    }

    public void TakeDamage(int damage)
    {
        int healthAfterDamage = health - damage;
        health = healthAfterDamage;
        SetHealthTo(healthAfterDamage);
    }

    public void Heal(int heal)
    {
        int healthAfterHeal = health + heal;
        SetHealthTo(healthAfterHeal);
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public virtual void InitVariables()
    {
        maxHealth = 100;
        SetHealthTo(maxHealth);
        isDead = false;
    }

    public object SaveState()
    {
        return new SaveData()
        {
            health = this.health
        };
    }

    public void LoadState(object state)
    {
        var saveData = (SaveData)state;
        health = saveData.health;
    }

    [Serializable]
    private struct SaveData
    {
        public int health;
    }
}
