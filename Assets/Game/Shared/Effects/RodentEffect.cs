using UnityEngine;

public class RodentEffect : MonoBehaviour
{
    public Rodent rodent;

    public float duration;

    public float startTime;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Effect", startTime);
        Invoke("StopEffect", duration);
    }

    protected virtual void Effect() { }

    protected virtual void StopEffect()
    {
        CancelInvoke();
        Destroy(this);
    }
        
   
}
