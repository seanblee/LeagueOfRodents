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

    private void Update()
    {
        RunDownLane();
    }

    public Team GetTeam()
    {
        return this.team;
    }

    public void SetTeam(Team team)
    {
        this.team = team;

        // temp: set color of minion to match team color
        this.GetComponent<Renderer>().material.color = (this.team == Team.Red ? Color.red : Color.blue);
    }

    public MinionType GetMinionType()
    {
        return this.minionType;
    }

    public void SetMinionType(MinionType minionType)
    {
        this.minionType = minionType;
    }

    public void Attack(Entity enemy)
    {
        if(this.minionType == MinionType.Melee)
        {
            // run up to the enemy and ravage
            if(Vector3.Distance(this.transform.position, enemy.transform.position) > attackRange) // if we aren't within attacking range
            {
                // gap close
                this.transform.position = Vector3.MoveTowards(this.transform.position, enemy.transform.position, this.moveSpeed * Time.deltaTime);
            }
            else
            {
                // RAVAGE
            }
        }
        else
        {
            // fire a projectile at the enemy
        }
    }

    private void RunDownLane()
    {
        // run it down the lane towards the enemy nexus

        Entity closestEnemy = ScanForEnemies();

        if(closestEnemy != null) // if we see an enemy
        {
            Attack(closestEnemy); // ravage
        }

    }


    // Gets the closest enemy unity TODO: implement priority
    private Entity ScanForEnemies()
    {
        // sphere cast and look for enemy minions/turrets/enemies
        // priority should be minions > turrets > champions

        RaycastHit[] hitInfo = Physics.SphereCastAll(this.transform.position, this.visionRadius, this.transform.forward);

        Entity closestEnemyEntity = null;
        if (hitInfo.Length > 0)
        {
            float distance = Mathf.Infinity; // distance set to max initially

            // look for the closest enemy
            foreach (RaycastHit hit in hitInfo)
            {
                Entity curr_entity;
                if((curr_entity = hit.transform.GetComponent<Entity>()) != null)
                {
                    if(curr_entity.team != this.team)
                    {
                        float distanceToTarget = Vector3.Distance(this.transform.position, hit.transform.position); // distance from us to curr entity
                        if (distanceToTarget < distance)
                        {
                            distance = distanceToTarget;
                            closestEnemyEntity = curr_entity;
                        }
                    }
                }
            }
        }
        return closestEnemyEntity;
    }
}
