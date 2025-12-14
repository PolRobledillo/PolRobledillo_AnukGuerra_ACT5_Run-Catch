using UnityEngine;

[CreateAssetMenu(fileName = "FinishedTelegraphingCharge", menuName = "Scriptable Objects/Conditions/FinishedTelegraphingCharge")]
public class FinishedTelegraphingCharge : AConditionSO
{
    public override bool CheckCondition(EnemyStateMachine enemy)
    {
        return enemy.finishedTelegraphingChargeAttack;
    }
}