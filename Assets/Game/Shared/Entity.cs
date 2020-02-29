using UnityEngine;

public class Entity : MonoBehaviour
{
    public Team Team { get; set; }

    public virtual void TakeDamage(float damage)
    {

    }
}
