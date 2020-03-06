using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : Entity
{
    public float currentHealth;

    public float health;

    protected float attackDamage;

    protected float attackSpeed;

    protected float attackRange;

    protected float moveSpeed;

    protected float visionRadius;

    public override void TakeDamage(float damage)
    {
        this.currentHealth -= damage;

        if(this.currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
