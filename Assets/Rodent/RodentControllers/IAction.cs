using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action
{
    public ActionType actionType;
}

public class MoveAction : Action
{
    public Vector3 location;

    public MoveAction(Vector3 location)
    {
        this.actionType = ActionType.MoveAction;
        this.location = location;
    }
}

public class StopAction: Action
{
    public StopAction()
    {
        this.actionType = ActionType.StopAction;
    }
}

public enum ActionType
{
    MoveAction,
    StopAction
}
