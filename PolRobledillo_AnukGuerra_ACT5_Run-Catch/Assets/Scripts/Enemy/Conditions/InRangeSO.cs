using UnityEngine;

[CreateAssetMenu(fileName = "InRangeSO", menuName = "Scriptable Objects/Conditions/InRangeSO")]
public class InRangeSO : AConditionSO
{
    public override bool CheckCondition(EnemyStateMachine enemy)
    {
        float distanceToPlayer = Vector3.Distance(enemy.transform.position, enemy.playerTransform.position);
        return distanceToPlayer <= enemy.chaseDistance;
    }
}