using System.Collections.Generic;
using UnityEngine;

public class Rodent : Entity
{
    public StatSheet statSheet;

    public RodentController rodentController;

    public int level;

    public float health;

    public float currentHealth;

    public float attackDamage;

    public float attackSpeed;

    public float attackRange;

    public float movementSpeed;

    // temp, todo: define exp to level up in parent 
    public int expToLevelUp;

    public int expCurrent;

    public bool IsDead;

    public Queue<Action> actionQueue;

    void Start()
    {
        rodentController = this.GetComponent<RodentController>();
        actionQueue = new Queue<Action>();
    }

    void Update()
    {
        if (actionQueue.Count > 0)
        {
            Action action = actionQueue.Dequeue();
            ExecuteAction(action);
        }
    }   

    public virtual void ExecuteAction(Action action)
    {

    }

    public void ClearQueue()
    {
        this.actionQueue = new Queue<Action>();
    }

    public void LevelUp()
    {
        this.level += 1;
        this.health += statSheet.healthPerLevel;
        this.currentHealth += statSheet.healthPerLevel;
        this.attackDamage += statSheet.attackDamagePerLevel;
        this.attackSpeed += statSheet.attackSpeedPerLevel;
        this.movementSpeed += statSheet.movementSpeedPerLevel;
    }

    public void TakeDamage(float damage)
    {
        if (currentHealth == 0)
        {
            this.IsDead = true;
        }
        else
        {
            this.currentHealth -= damage;
        }
    }

    public void GainExp(int exp)
    {
        if (expCurrent >= expToLevelUp)
        {
            LevelUp();
            int residualXp = expCurrent - expToLevelUp;
            expCurrent = residualXp;
        }
        this.expCurrent += exp;

    }

    public void DebugStats()
    {
        Debug.Log("Health: " + this.health + " Level: " + this.level);
    }
}
