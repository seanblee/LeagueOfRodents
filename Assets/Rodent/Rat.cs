using System.Collections;
using System.IO;
using UnityEngine;

public class Rat : Rodent
{
    void Awake()
    {
        ReadStats();
        this.level = 1;
        this.expCurrent = 0;
        this.expToLevelUp = 100;
        this.health = statSheet.baseHealth;
        this.currentHealth = statSheet.baseHealth;
        this.attackDamage = statSheet.baseAttackDamage;
        this.attackSpeed = statSheet.baseAttackSpeed;
        this.attackRange = statSheet.baseAttackRange;
        this.movementSpeed = statSheet.baseMovementSpeed;
        this.IsDead = false;
    }

    public override void ExecuteAction(Action action)
    {
        base.ExecuteAction(action);
        switch (action.actionType)
        {
            case ActionType.MoveAction:
                ClearQueue();
                var moveAction = action as MoveAction;
                rodentController.MoveTo(moveAction.location);
                break;
            case ActionType.StopAction:
                ClearQueue();
                rodentController.MoveTo(rodentController.transform.position);
                break;
            case ActionType.AttackAction:
                var attackAction = action as AttackAction;
                Attack(attackAction.attackEntity);
                break;
            case ActionType.QSpellAction:
                RatFrenzy();
                break;
        }
    }

    public void Attack(Entity enemy)
    { 
        if (enemy != null)
        {
            float distToEnemy = Vector3.Distance(this.transform.position, enemy.transform.position);
            if (distToEnemy > attackRange)
            {
                nextDamageEvent = Time.time + 1 / attackSpeed;
                rodentController.MoveTo(enemy.transform.position);
            }
            else
            {
                rodentController.MoveTo(rodentController.transform.position);
                if (Time.time >= nextDamageEvent)
                {
                    nextDamageEvent = Time.time + 1 / attackSpeed;
                    enemy.TakeDamage(this.attackDamage);
                }
            }
            this.actionQueue.Enqueue(new AttackAction(enemy));
        } 
    }

    private void RatFrenzy()
    {
        var attackSpeedBuff = this.gameObject.AddComponent<AtkSpeedBuffEffect>();
        attackSpeedBuff.rodent = this;
        attackSpeedBuff.duration = 3;
        attackSpeedBuff.startTime = 0;
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

}