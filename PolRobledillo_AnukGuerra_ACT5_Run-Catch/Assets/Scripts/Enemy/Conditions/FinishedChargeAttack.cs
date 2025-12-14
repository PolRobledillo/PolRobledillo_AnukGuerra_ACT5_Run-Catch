using UnityEngine;

[CreateAssetMenu(fileName = "FinishedChargeAttack", menuName = "Scriptable Objects/Conditions/FinishedChargeAttack")]
public class FinishedChargeAttack : AConditionSO
{
    public override bool CheckCondition(EnemyStateMachine enemy)
    {
        return !enemy.performingChargeAttack;
    }
}