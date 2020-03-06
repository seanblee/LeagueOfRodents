using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class NexusHealthBar : MonoBehaviour
{
    [SerializeField] Image healthBar;

    [SerializeField] Nexus nexus;

    private float maxHealth;

    private float currentHealth;

    private Quaternion mainCameraRotation;

    void Start()
    {
        mainCameraRotation = Camera.main.transform.rotation;
    }

    void Update()
    {
        maxHealth = nexus.health;
        currentHealth = nexus.currentHealth;

        healthBar.transform.localScale = currentHealth >= 0 ? new Vector3(currentHealth / maxHealth, 1, 1) : Vector3.zero;
    }

    void LateUpdate()
    {
        this.transform.LookAt(this.transform.position + mainCameraRotation * Vector3.forward, mainCameraRotation * Vector3.up);
    }
}
