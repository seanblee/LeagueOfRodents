using UnityEngine;
using UnityEngine.AI;

public class RodentController : MonoBehaviour
{
    public Rodent rodent;

    public Camera rodentCamera;

    public LayerMask groundLayer;

    public NavMeshAgent rodentAgent;

    void Awake()
    {
        rodentCamera = Camera.main;
        groundLayer = LayerMask.GetMask("Ground");
        rodentAgent = GetComponentInParent<NavMeshAgent>();
    }

    void Start()
    {
        rodent = this.GetComponent<Rodent>();
    }

    void Update()
    {
        rodentAgent.speed = rodent.movementSpeed;

        if (Input.GetMouseButtonDown(1))
        {
            var rh = GetPointUnderCursor();
            switch (rh.collider.name)
            {
                case "Terrain":
                    var moveAction = new MoveAction(rh.point);
                    rodent.actionQueue.Enqueue(moveAction);
                    break;
                case 
            }
            
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            var stopAction = new StopAction();
            rodent.actionQueue.Enqueue(stopAction);
        }
    }

    public void MoveTo(Vector3 location)
    {
        rodentAgent.SetDestination(location);
    }

    private RaycastHit GetPointUnderCursor()
    {
        Vector3 mouseWorldPosition = rodentCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 40));
        RaycastHit hitPosition;
        Physics.Raycast(mouseWorldPosition, rodentCamera.transform.forward, out hitPosition, 100, groundLayer);

        return hitPosition;
    }
}