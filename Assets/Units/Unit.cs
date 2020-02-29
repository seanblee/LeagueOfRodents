using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    protected float health;

    public float currentHealth;

    protected float attackDamage;

    protected float attackSpeed;

    protected float attackRange;

    protected float moveSpeed;

    protected float visionRadius;

    public bool isDead;

    public void TakeDamage(float damage)
    {
        this.currentHealth -= damage;

        isDead |= this.currentHealth <= 0;
    }
}
