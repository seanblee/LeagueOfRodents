using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Rat : MonoBehaviour, IRodent
{
    private StatSheet statSheet;

    private int level;

    private float health;

    private float currentHealth;

    private float attackDamage;

    private float attackSpeed;

    private float movementSpeed;

    private int expToLevelUp;

    private int expCurrent;

    private bool isDead;

    public Rat()
    {
        ReadStats();
        this.level = 1;
        this.expCurrent = 0;
        this.expToLevelUp = 100;
        this.health = statSheet.baseHealth;
        this.currentHealth = statSheet.baseHealth;
        this.attackDamage = statSheet.baseAttackDamage;
        this.attackSpeed = statSheet.baseAttackSpeed;
        this.movementSpeed = statSheet.baseMovementSpeed;
        this.isDead = false;
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
            this.isDead = true;
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

    public int GetCurrentLevel()
    {
        return this.level;
    }

    public float GetCurrentHealth()
    {
        return this.currentHealth;
    }

    public float GetHealth()
    {
        return this.health;
    }

    public float GetMovement()
    {
        return this.movementSpeed;
    }

    public float GetCurrentExp()
    {
        return this.expCurrent;
    }

    public StatSheet GetStatSheet()
    {
        return this.statSheet;
    }

    public void ReadStats()
    {
        string rodentDirectory = "Assets/Rodent/RodentDocs/Rat.json";
        string json = string.Empty;

        using (StreamReader sr = new StreamReader(rodentDirectory))
        {
            json = sr.ReadToEnd();
        }

        this.statSheet = JsonUtility.FromJson<StatSheet>(json);
    }

    public void DebugStats()
    {
        Debug.Log("Health: " + this.health + " Level: " + this.level);
    }
}