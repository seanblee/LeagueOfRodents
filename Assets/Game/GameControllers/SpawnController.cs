using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnController : MonoBehaviour
{
    [SerializeField]
    private GameObject rodentPrefab;

    void Awake()
    {
        SpawnRodent(RodentType.Rat);
    }

    void Update()
    {

    }

    void SpawnRodent(RodentType rodentType)
    {
        GameObject spawnRodent = Instantiate(rodentPrefab, new Vector3(0,0,0), Quaternion.identity);

        var controller = spawnRodent.AddComponent(typeof(RodentController));
        Camera.main.GetComponent<CameraController>().player = spawnRodent.transform;

        switch (rodentType)
        {
            case RodentType.Rat:
                var rat = spawnRodent.AddComponent(typeof(Rat)) as Rat;
                rat.team = Team.Red;
                break;
        }
    }
}
