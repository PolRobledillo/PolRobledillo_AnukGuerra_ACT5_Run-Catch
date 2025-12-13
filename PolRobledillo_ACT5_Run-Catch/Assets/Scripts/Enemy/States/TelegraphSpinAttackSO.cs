using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(fileName = "TelegraphSpinAttackSO", menuName = "Scriptable Objects/EnemyStates/TelegraphSpinAttackSO")]
public class TelegraphSpinAttackSO : AStateSO
{
    public override void OnStateEnter(EnemyStateMachine enemy)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.AppendCallback(() =>
        {
            enemy.telegraphSpinAttackEffect.SetActive(true);
            enemy.animator.SetBool("ChargingAttack", true);
            enemy.animator.SetTrigger("SpinAttack");
        })
                .Append(enemy.telegraphSpinAttackEffectImage.transform.DOScale(1, enemy.telegraphSpinDuration).SetEase(Ease.Linear))
                .AppendCallback(() => enemy.finishedTelegraphingSpinAttack = true);
    }
    public override void OnStateUpdate(EnemyStateMachine enemy)
    {
    }
    public override void OnStateExit(EnemyStateMachine enemy)
    {
        enemy.telegraphSpinAttackEffect.SetActive(false);
        enemy.telegraphSpinAttackEffectImage.transform.DOScale(0, 0);
        enemy.animator.SetBool("ChargingAttack", false);
    }
}
