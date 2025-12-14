
using UnityEngine;

[CreateAssetMenu(fileName = "FinishedSpinAttack", menuName = "Scriptable Objects/Conditions/FinishedSpinAttack")]
public class FinishedSpinAttack : AConditionSO
{
    public override bool CheckCondition(EnemyStateMachine enemy)
    {
        return !enemy.performingSpinAttack;
    }
}