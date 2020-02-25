﻿using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RodentStatBarController : MonoBehaviour
{
    private IRodent rodent;

    private Quaternion mainCameraRotation;

    private TextMeshProUGUI textMesh;

    private TextMeshProUGUI levelMesh;

    private Image healthBar;

    private Image expBar;

    private float maxHealth;

    private float maxExp;

    private float currentHealth;

    private float currentExp;

    void Start()
    {
        rodent = this.transform.parent.GetComponent<IRodent>();

        mainCameraRotation = Camera.main.transform.rotation;
        textMesh = GameObject.Find("Username").GetComponent<TextMeshProUGUI>();
        healthBar = GameObject.Find("UserHealthBar").GetComponent<Image>();
        expBar = GameObject.Find("UserExpBar").GetComponent<Image>();
        levelMesh = GameObject.Find("UserLevel").GetComponent<TextMeshProUGUI>();

        textMesh.text = rodent.GetStatSheet().name;

        // Define max xp level up chart in game stat controller, placeholder 100
        maxExp = 100;
    }

    private void Update()
    {
        maxHealth = rodent.GetHealth();
        currentHealth = rodent.GetCurrentHealth();
        currentExp = rodent.GetCurrentExp();
        levelMesh.text = rodent.GetCurrentLevel().ToString();

        healthBar.transform.localScale = new Vector3(currentHealth / maxHealth, 1, 1);
        expBar.transform.localScale = new Vector3(currentExp / maxExp, 1, 1);
        expBar.transform.localScale = new Vector3(currentExp / maxExp, 1, 1);
    }

    void LateUpdate()
    {
        this.transform.LookAt(this.transform.position + mainCameraRotation * Vector3.forward, mainCameraRotation * Vector3.up);
    }
}
