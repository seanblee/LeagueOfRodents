using UnityEngine;
using UnityEngine.UI;

public class GenericHealthBar : MonoBehaviour
{
    private Quaternion mainCameraRotation;

    [SerializeField] Image healthBar;

    private float maxHealth;

    private float currentHealth;

    [SerializeField] Unit unit;

    void Start()
    {
        mainCameraRotation = Camera.main.transform.rotation;
    }

    void Update()
    {
        maxHealth = unit.GetHealth();
        currentHealth = unit.currentHealth;
        if(currentHealth >= 0)
        {
            healthBar.transform.localScale = new Vector3(currentHealth / maxHealth, 1, 1);
        }
        else
        {
            healthBar.transform.localScale = Vector3.zero;
        }

        if(currentHealth <= 0)
        {
            Destroy(unit.gameObject);
        }
    }

    void LateUpdate()
    {
        this.transform.LookAt(this.transform.position + mainCameraRotation * Vector3.forward, mainCameraRotation * Vector3.up);
    }
}
