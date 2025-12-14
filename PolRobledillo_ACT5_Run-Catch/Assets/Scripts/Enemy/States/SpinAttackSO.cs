using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "SpinAttackSO", menuName = "Scriptable Objects/EnemyStates/SpinAttackSO")]
public class SpinAttackSO : AStateSO
{
    public override void OnStateEnter(EnemyStateMachine enemy)
    {
        enemy.animator.SetBool("PerformingAttack", true);
        enemy.performAttack = -1;

        enemy.finishedTelegraphingSpinAttack = false;
        enemy.spinAttackCollider.enabled = true;
        enemy.performingSpinAttack = true;
        enemy.isSpinning = true;

    }
    public override void OnStateUpdate(EnemyStateMachine enemy)
    {
        if (enemy.isSpinning)
        {
            enemy.spinTimer += Time.deltaTime;
            if (enemy.spinTimer >= enemy.spinAttackDuration)
            {
                enemy.isSpinning = false;
                enemy.animator.SetBool("PerformingAttack", false);
                enemy.spinTimer = 0f;
                enemy.performingSpinAttack = false;
                enemy.cooldownTimerSpinAttack = enemy.cooldownBetweenSpinAttacks;
            }
            else
            {
                float rotationThisFrame = enemy.spinSpeed * Time.deltaTime;
                enemy.transform.Rotate(Vector3.up, rotationThisFrame);
            }
        }
    }

    public override void OnStateExit(EnemyStateMachine enemy)
    {
        enemy.spinAttackCollider.enabled = false;        
    }
}
