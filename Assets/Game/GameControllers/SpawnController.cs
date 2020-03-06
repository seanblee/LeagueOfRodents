using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnController : MonoBehaviour
{
    [SerializeField] GameObject ratPrefab;

    void Awake()
    {
        SpawnRodent(RodentType.Rat);
    }

    void SpawnRodent(RodentType rodentType)
    {
        GameObject spawnedRodent;

        switch (rodentType)
        {
            case RodentType.Rat:
                spawnedRodent = Instantiate(ratPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                var rat = spawnedRodent.AddComponent(typeof(Rat)) as Rat;
                rat.Team = Team.Red;
                break;
            default:
                spawnedRodent = null;
                break;
        }
        
        if(spawnedRodent != null)
        {
            spawnedRodent.AddComponent(typeof(RodentController));
            Camera.main.GetComponent<CameraController>().player = spawnedRodent.transform;
        }
    }
}
