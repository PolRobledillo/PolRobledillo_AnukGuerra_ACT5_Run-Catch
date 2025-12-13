using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(fileName = "SpinAttackSO", menuName = "Scriptable Objects/EnemyStates/SpinAttackSO")]
public class SpinAttackSO : AStateSO
{
    public override void OnStateEnter(EnemyStateMachine enemy)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.AppendCallback(() =>
        {
            enemy.finishedTelegraphingSpinAttack = false;
            enemy.spinAttackCollider.enabled = true;
            enemy.performingSpinAttack = true;
        })
                .Append(enemy.transform.DORotate(new Vector3(0, 3600, 0), enemy.spinAttackDuration));
    }
    public override void OnStateUpdate(EnemyStateMachine enemy)
    {
    }
    public override void OnStateExit(EnemyStateMachine enemy)
    {
        enemy.spinAttackCollider.enabled = false;
        enemy.performingSpinAttack = false;
    }
}
