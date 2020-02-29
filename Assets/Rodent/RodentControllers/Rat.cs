using System.IO;
using UnityEngine;

public class Rat : Rodent
{
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
        this.IsDead = false;
    }

    public override void ExecuteAction(Action action)
    {
        base.ExecuteAction(action);
        switch (action.actionType)
        {
            case ActionType.MoveAction:
                var moveAction = action as MoveAction;
                rodentController.MoveTo(moveAction.location);
                break;
            case ActionType.StopAction:
                rodentController.MoveTo(rodentController.transform.position);
                break;
        }
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