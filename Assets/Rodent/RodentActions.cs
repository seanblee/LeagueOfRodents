using UnityEngine;

public class MoveAction : Action
{
    public Vector3 location;

    public MoveAction(Vector3 location)
    {
        this.actionType = ActionType.MoveAction;
        this.location = location;
    }
}

public class StopAction : Action
{
    public StopAction()
    {
        this.actionType = ActionType.StopAction;
    }
}

public class AttackAction : Action
{
    public Entity attackEntity;

    public AttackAction(Entity attackEntity)
    {
        this.actionType = ActionType.AttackAction;
        this.attackEntity = attackEntity;
    }
}