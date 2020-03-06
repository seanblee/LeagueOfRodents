using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action
{
    public ActionType actionType;
}

public enum ActionType
{
    MoveAction,
    StopAction,
    AttackAction,
    QSpellAction,
}
