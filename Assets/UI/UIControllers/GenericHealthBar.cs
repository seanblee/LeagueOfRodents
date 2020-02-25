using UnityEngine;
using UnityEngine.UI;

public class GenericHealthBar : MonoBehaviour
{
    private Quaternion mainCameraRotation;

    private Image healthBar;

    private float maxHealth;

    private float currentHealth;

    void Start()
    {
        mainCameraRotation = Camera.main.transform.rotation;
    }

    void Update()
    {
        
    }

    void LateUpdate()
    {
        this.transform.LookAt(this.transform.position + mainCameraRotation * Vector3.forward, mainCameraRotation * Vector3.up);
    }
}
