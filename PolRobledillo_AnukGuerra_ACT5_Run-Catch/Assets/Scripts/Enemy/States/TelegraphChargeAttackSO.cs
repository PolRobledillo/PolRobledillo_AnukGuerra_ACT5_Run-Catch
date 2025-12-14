using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(fileName = "TelegraphChargeAttackSO", menuName = "Scriptable Objects/EnemyStates/TelegraphChargeAttackSO")]
public class TelegraphChargeAttackSO : AStateSO
{
    public override void OnStateEnter(EnemyStateMachine enemy)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.AppendCallback(() =>
                {
                    enemy.telegraphChargeAttackEffect.SetActive(true);
                    enemy.animator.SetBool("ChargingAttack", true);
                    enemy.animator.SetTrigger("ChargeAttack");
                })
                .Append(enemy.telegraphChargeAttackEffectImage.transform.DOScaleY(1, enemy.telegraphChargeDuration).SetEase(Ease.Linear))
                .AppendCallback(() => enemy.finishedTelegraphingChargeAttack = true);
    }
    public override void OnStateUpdate(EnemyStateMachine enemy)
    {
    }
    public override void OnStateExit(EnemyStateMachine enemy)
    {
        enemy.telegraphChargeAttackEffect.SetActive(false);
        enemy.telegraphChargeAttackEffectImage.transform.DOScaleY(0, 0);
        enemy.animator.SetBool("ChargingAttack", false);
    }
}
