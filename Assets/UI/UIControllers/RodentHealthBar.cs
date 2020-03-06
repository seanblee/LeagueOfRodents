using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RodentHealthBar : MonoBehaviour
{
    [SerializeField] Rodent rodent;

    [SerializeField] TextMeshProUGUI username;

    [SerializeField] TextMeshProUGUI level;

    [SerializeField] Image healthBar;

    [SerializeField] Image expBar;

    private Quaternion mainCameraRotation;

    private float maxHealth;

    private float maxExp;

    private float currentHealth;

    private float currentExp;

    void Start()
    {
        this.rodent = this.GetComponentInParent<Rodent>(); // need this in start bc Sean B Lee added components in Awake()

        this.mainCameraRotation = Camera.main.transform.rotation;
        this.username.text = rodent.statSheet.name;

        // Define max xp level up chart in game stat controller, placeholder 100
        this.maxExp = 100;
    }

    private void Update()
    {
        maxHealth = rodent.health;
        currentHealth = rodent.currentHealth;
        currentExp = rodent.expCurrent;
        level.text = rodent.level.ToString();

        healthBar.transform.localScale = currentHealth >= 0 ? new Vector3(currentHealth / maxHealth, 1, 1) : Vector3.zero;
        expBar.transform.localScale = new Vector3(currentExp / maxExp, 1, 1);
        expBar.transform.localScale = new Vector3(currentExp / maxExp, 1, 1);
    }

    void LateUpdate()
    {
        this.transform.LookAt(this.transform.position + mainCameraRotation * Vector3.forward, mainCameraRotation * Vector3.up);
    }
}
