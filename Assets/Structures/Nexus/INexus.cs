using System.Collections.Generic;
using UnityEngine;

public interface INexus
{
    void SpawnMinion();

    float GetNexusHealth();

    List<GameObject> GetNexusMinions();

    string GetNexusTeam();
}
