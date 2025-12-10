using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;

public class EnemyStateMachine : MonoBehaviour
{
    public enum EnemyState
    {
        Idle,
        Chase,
        TelegraphChargeAttack,
        ChargeAttack,
        TelegraphSpinAttack,
        SpinAttack
    }

    [Header("References")]
    public Transform playerTransform;
    public NavMeshAgent navMeshAgent;
    public Animator animator;

    [Header("State Machine")]
    public AStateSO currentState;
    public EnemyState state = EnemyState.Idle;
    public List<AStateSO> states;

    [Header("Chase Settings")]
    public float chaseDistance = 10f;
    public float forgetDistance = 15f;
    public float chaseSpeed = 3.5f;

    [Header("Charge Attack Settings")]
    public float cooldownBetweenChargeAttacks = 5f;
    public float chargeAttackDamage = 25f;
    public float chargeAttackSpeed = 8f;

    [Header("Telegraph Charge Attack Settings")]
    public float telegraphChargeDuration = 2f;

    [Header("Spin Attack Settings")]
    public float cooldownBetweenSpinAttacks = 7f;
    public float spinAttackDuration = 3f;
    public float spinAttackDamagePerSecond = 15f;

    [Header("Telegraph Spin Attack Settings")]
    public float telegraphSpinDuration = 2f;

    private void Start()
    {
        if (currentState != null)
        {
            currentState.OnStateEnter(this);
        }
    }
    private void Update()
    {
        currentState.OnStateUpdate(this);
        CheckEndingConditions();
    }
    void CheckEndingConditions()
    {
        foreach (AConditionSO condition in currentState.endConditions)
        {
            if (condition.CheckCondition(this) == condition.answer)
            {
                ExitCurrentNode();
                break;
            }
        }
    }
    void ExitCurrentNode()
    {
        foreach (AStateSO stateSO in states)
        {
            if (stateSO.startCondition == null)
            {
                EnterState(stateSO);
                break;
            }
            else if (stateSO.startCondition.CheckCondition(this) == stateSO.startCondition.answer)
            {
                EnterState(stateSO);
                break;
            }
        }
    }
    void EnterState(AStateSO newState)
    {
        currentState.OnStateExit(this);
        currentState = newState;
        currentState.OnStateEnter(this);
    }
}
