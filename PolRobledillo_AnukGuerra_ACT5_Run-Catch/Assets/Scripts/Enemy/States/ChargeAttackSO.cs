using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(fileName = "ChargeAttackSO", menuName = "Scriptable Objects/EnemyStates/ChargeAttackSO")]
public class ChargeAttackSO : AStateSO
{
    public override void OnStateEnter(EnemyStateMachine enemy)
    {
        enemy.performAttack = -1;
        Sequence sequence = DOTween.Sequence();
        sequence.AppendCallback(() =>
                {
                    enemy.finishedTelegraphingChargeAttack = false;
                    enemy.chargeAttackCollider.enabled = true;
                    enemy.performingChargeAttack = true;
                })
                .Append(enemy.transform.DOLocalMove(enemy.transform.position + (enemy.transform.forward * enemy.chargeDistance), enemy.chargeTime))
                .AppendCallback(() =>
                {
                    enemy.performingChargeAttack = false;
                    enemy.cooldownTimerChargeAttack = enemy.cooldownBetweenChargeAttacks;
                });
    }
        
    public override void OnStateUpdate(EnemyStateMachine enemy)
    {
    }
    public override void OnStateExit(EnemyStateMachine enemy)
    {
        enemy.chargeAttackCollider.enabled = false;
    }
}
