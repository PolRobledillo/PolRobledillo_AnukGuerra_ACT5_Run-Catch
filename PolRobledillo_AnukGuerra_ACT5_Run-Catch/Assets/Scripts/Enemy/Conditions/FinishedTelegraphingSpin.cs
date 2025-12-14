using UnityEngine;

[CreateAssetMenu(fileName = "FinishedTelegraphingSpin", menuName = "Scriptable Objects/Conditions/FinishedTelegraphingSpin")]
public class FinishedTelegraphingSpin : AConditionSO
{
    public override bool CheckCondition(EnemyStateMachine enemy)
    {
        return enemy.finishedTelegraphingSpinAttack;
    }
}