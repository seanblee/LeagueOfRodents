using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nexus : MonoBehaviour, INexus
{
    [Header("Minion Prefab")]
    [SerializeField] GameObject _minion_prefab; // reference to prefab object

    [Space]
    [Header("Team Settings")]
    [SerializeField] string _team; // which team the nexus belongs to (replace type with custom class/enum)

    private float _nexus_health;
    private List<GameObject> _minions; // list of minions that belong to the nexus

    void Start()
    {
        _minions = new List<GameObject>();    
    }

    public void SpawnMinion()
    {
        // instantiate a minion prefab at the world space origin
        _minions.Add(Instantiate(_minion_prefab, Vector3.zero, Quaternion.identity));
    }

    public float GetNexusHealth()
    {
        return _nexus_health;
    }

    public List<GameObject> GetNexusMinions()
    {
        return _minions;
    }

    public string GetNexusTeam()
    {
        return _team;
    }
}
