using UnityEngine;

[CreateAssetMenu(fileName = "ChaseSO", menuName = "Scriptable Objects/EnemyStates/ChaseSO")]
public class ChaseSO : AStateSO
{
    public override void OnStateEnter(EnemyStateMachine enemy)
    {
    }
    public override void OnStateUpdate(EnemyStateMachine enemy)
    {
        enemy.navMeshAgent.SetDestination(enemy.playerTransform.position);
    }
    public override void OnStateExit(EnemyStateMachine enemy)
    {
        enemy.navMeshAgent.ResetPath();
    }
}
