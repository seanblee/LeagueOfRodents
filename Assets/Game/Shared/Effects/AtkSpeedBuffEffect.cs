using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkSpeedBuffEffect : RodentEffect
{
    protected override void Effect()
    {
        this.rodent.transform.localScale += new Vector3(0.2f, 0, 0.2f);
        this.rodent.attackRange += 0.5f;
        this.rodent.attackSpeed = this.rodent.attackSpeed * 3;
    }

    protected override void StopEffect()
    {
        this.transform.localScale -= new Vector3(0.2f, 0, 0.2f);
        this.rodent.attackRange -= 0.5f;
        this.rodent.attackSpeed = this.rodent.attackSpeed / 3;
    }
}
