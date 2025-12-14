using UnityEngine;

[CreateAssetMenu(fileName = "InRangeForgetSO", menuName = "Scriptable Objects/Conditions/InRangeForgetSO")]
public class InRangeForgetSO : AConditionSO
{
    public override bool CheckCondition(EnemyStateMachine enemy)
    {
        float distanceToPlayer = Vector3.Distance(enemy.transform.position, enemy.playerTransform.position);
        return distanceToPlayer <= enemy.forgetDistance;
    }
}