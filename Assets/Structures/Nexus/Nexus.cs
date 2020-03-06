using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nexus : Entity
{
    [Header("Minion Settings")]
    [SerializeField] GameObject minionPrefab; // reference to prefab object
    [SerializeField] Transform minionSpawnPoint;

    [Header("Team Settings")]
    [SerializeField] Team setTeam;

    private float nexusHealth;
    private float nexusCurrentHealth;

    void Start()
    {
        this.nexusHealth = nexusCurrentHealth = 500;
        this.Team = setTeam;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SpawnMinion(MinionType.Melee);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            SpawnMinion(MinionType.Ranged);
        }
    }

    public void SpawnMinion(MinionType minionType)
    {
        // instantiate a minion prefab at the world space origin
        GameObject newMinionGO = Instantiate(minionPrefab, this.minionSpawnPoint.position, Quaternion.identity);
        Minion newMinion = newMinionGO.GetComponent<Minion>();
        newMinion.Team = this.Team;
        // set team color
        newMinion.transform.GetComponent<Renderer>().material.color = newMinion.Team == Team.Red ? Color.red : Color.blue;
        newMinion.SetMinionType(minionType);
    }

    public float GetNexusHealth()
    {
        return nexusCurrentHealth;
    }

    public override void TakeDamage(float damage)
    {
        this.nexusCurrentHealth -= damage;
    }
}
