using UnityEngine;

[CreateAssetMenu(fileName = "InRangeChargeAttackSO", menuName = "Scriptable Objects/Conditions/InRangeChargeAttackSO")]
public class InRangeChargeAttackSO : AConditionSO
{
    public override bool CheckCondition(EnemyStateMachine enemy)
    {
        float distanceToPlayer = Vector3.Distance(enemy.transform.position, enemy.playerTransform.position);
        return distanceToPlayer <= enemy.chargeDistance && enemy.performAttack == 1 && enemy.cooldownTimerChargeAttack <= 1; //Enemy performAttack is hardcoded make a list of attacks in a enumerator later
    }
}