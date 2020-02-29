using System;
using System.IO;
using UnityEngine;

[Serializable]
public class StatSheet
{
    public string name;

    public string description;

    public float baseHealth;

    public float baseAttackDamage;

    public float baseAttackSpeed;

    public float baseAttackRange;

    public float baseMovementSpeed;

    public float healthPerLevel;

    public float attackDamagePerLevel;

    public float attackSpeedPerLevel;

    public float movementSpeedPerLevel;
}