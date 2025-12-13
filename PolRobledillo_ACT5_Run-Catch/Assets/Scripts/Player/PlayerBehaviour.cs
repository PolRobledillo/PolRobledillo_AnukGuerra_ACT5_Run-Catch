using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using static InputSystem_Actions;

public class PlayerBehaviour : MonoBehaviour, IPlayerActions, IDamageable
{
    private static InputSystem_Actions inputActions;

    [Header("Pathfinding Settings")]
    [SerializeField] NavMeshAgent navmeshAgent;

    [Header("Player Settings")]
    public int maxHealth = 100;
    public int currentHealth = 100;
    public RectTransform healthBar;
    private float healthBarMaxWidth = 580f;
    public Vector3 spawnPoint;

    private Animator animator;
    public int damageTest = 0;

    void Awake()
    {
        inputActions = new InputSystem_Actions();
        inputActions.Player.SetCallbacks(this);
        inputActions.Player.Enable();
        navmeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        spawnPoint = transform.position;
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
                animator.SetBool("Walking", true);
            }
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        float healthPercentage = (float)currentHealth / maxHealth;
        healthBar.sizeDelta = new Vector2(healthBarMaxWidth * healthPercentage, healthBar.sizeDelta.y);
        animator.SetTrigger("GetHit");
        if (currentHealth <= 0)
        {
            animator.SetTrigger("Die");
            navmeshAgent.ResetPath();
            this.enabled = false;
            StartCoroutine(Respawn());
        }
    }
    void Update()
    {
        if (damageTest == 1)
        {
            damageTest = 0;
            TakeDamage(10);
        }
        if (navmeshAgent.remainingDistance <= navmeshAgent.stoppingDistance)
        {
            animator.SetBool("Walking", false);
        }
    }
    public IEnumerator Respawn()
    {
        while (!animator.GetCurrentAnimatorStateInfo(0).IsName("Cactus_Die"))
        {
            yield return new WaitForSeconds(2f);
        }
        currentHealth = maxHealth;
        float healthPercentage = (float)currentHealth / maxHealth;
        healthBar.sizeDelta = new Vector2(healthBarMaxWidth * healthPercentage, healthBar.sizeDelta.y);
        transform.position = spawnPoint;
        animator.SetTrigger("Respawn");
        this.enabled = true;
    }
}
