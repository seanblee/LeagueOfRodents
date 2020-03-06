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
                default:
                    var attackEntity = rh.collider.gameObject.GetComponent<Entity>();
                    var attackAction = new AttackAction(attackEntity);
                    rodent.actionQueue.Enqueue(attackAction);
                    break;
            }
            
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            var rh = GetPointUnderCursor();
            rodent.actionQueue.Enqueue(new QSpellAction(rh));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            rodent.actionQueue.Enqueue(new StopAction());
        }
    }

    public void MoveTo(Vector3 location)
    {
        rodentAgent.SetDestination(location);
    }

    private RaycastHit GetPointUnderCursor()
    {
        RaycastHit hitPosition;
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitPosition, 100, groundLayer);

        return hitPosition;
    }
}