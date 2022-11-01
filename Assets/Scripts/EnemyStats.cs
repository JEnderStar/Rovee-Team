using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    [SerializeField] private float damage;
    [SerializeField] private float attackSpeed;

    [SerializeField] private bool canAttack;

    private void Start()
    {
        InitVariables();
    }
    public void DealDamage()
    {
        //Damaging Functionality
    }

    public override void Die()
    {
        base.Die();
        Destroy(gameObject);
    }

    public override void InitVariables()
    {
        maxHealth = 50;
        SetHealthTo(maxHealth);
        isDead = false;

        damage = 10;
        attackSpeed = 1.5f;
        canAttack = true;
    }
}
