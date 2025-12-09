using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using static InputSystem_Actions;

public class PlayerBehaviour : MonoBehaviour, IPlayerActions
{
    private static InputSystem_Actions inputActions;

    [Header("Pathfinding Settings")]
    [SerializeField] NavMeshAgent navmeshAgent;

    void Awake()
    {
        inputActions = new InputSystem_Actions();
        inputActions.Player.SetCallbacks(this);
        inputActions.Player.Enable();
        navmeshAgent = GetComponent<NavMeshAgent>();
    }
    void OnEnable()
    {
        inputActions.Enable();
    }
    void OnDisable()
    {
        inputActions.Disable();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(mouseScreenPos);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                navmeshAgent.SetDestination(hitInfo.point);
            }
        }
    }
}
