using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MinionType
{
    Melee,
    Ranged
}

public class Minion : Unit
{
    private Team currTeam;
    private MinionType minionType;

    void Start()
    {
        this.health = this.currentHealth = 5;
        this.attackDamage = 2;
        this.attackSpeed = 2;
        this.moveSpeed = 2;
        this.visionRadius = 5;
        this.isDead = false;
        this.attackRange = (this.minionType == MinionType.Melee ? 2 : 5);
    }

    public Team GetTeam()
    {
        return currTeam;
    }

    public void SetTeam(Team team)
    {
        currTeam = team;
    }

    public MinionType GetMinionType()
    {
        return this.minionType;
    }

    public void SetMinionType(MinionType minionType)
    {
        this.minionType = minionType;
    }

    public void Attack(Minion enemyMinion) // should be able to attack any entity
    {
        if(this.minionType == MinionType.Melee)
        {
            // run up to the enemy and ravage

        }
        else
        {
            // fire a projectile at the enemy
        }
    }

    private void RunDownLane()
    {
        // run it down the lane towards the enemy nexus

    }

    private void ScanForEnemies()
    {
        // sphere cast and look for enemy minions/turrets/enemies
        // priority should be minions > turrets > enemies

        RaycastHit[] hitInfo = Physics.SphereCastAll(this.transform.position, this.visionRadius, this.transform.forward);

        if(hitInfo.Length > 0)
        {
            foreach(RaycastHit hit in hitInfo) // loop through each object hit in the sphere cast
            {
                Minion curr_minion;
                if((curr_minion = hit.transform.GetComponent<Minion>()) != null) // if we hit a minion
                {
                    Attack(curr_minion);
                }
            }
        }
    }
}
