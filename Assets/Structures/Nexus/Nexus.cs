using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Team
{
    Red,
    Blue
}
public class Nexus : MonoBehaviour, INexus
{
    [Header("Minion Settings")]
    [SerializeField] GameObject minionPrefab; // reference to prefab object
    [SerializeField] Transform minionSpawnPoint;

    [Header("Team Settings")]
    [SerializeField] Team team; // which team the nexus belongs to (replace type with custom class/enum)

    private float nexusHealth;
    private float nexusCurrentHealth;

    void Start()
    {
        this.nexusHealth = nexusCurrentHealth = 500; 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SpawnMinion(MinionType.Melee);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            SpawnMinion(MinionType.Ranged);
        }
    }

    public void SpawnMinion(MinionType minionType)
    {
        // instantiate a minion prefab at the world space origin
        GameObject newMinionGO = Instantiate(minionPrefab, this.minionSpawnPoint.position, Quaternion.identity);
        Minion newMinion = newMinionGO.GetComponent<Minion>();
        newMinion.SetTeam(this.team);
        newMinion.SetMinionType(minionType);
    }

    public float GetNexusHealth()
    {
        return nexusCurrentHealth;
    }

    public Team GetNexusTeam()
    {
        return team;
    }

    public void TakeDamage(float damage)
    {
        this.nexusCurrentHealth -= damage;
        if(nexusCurrentHealth <= 0)
        {
            // TODO: die
        }
    }
}
