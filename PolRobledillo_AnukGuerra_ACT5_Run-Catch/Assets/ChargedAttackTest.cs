using DG.Tweening;
using UnityEngine;

public class ChargedAttackTest : MonoBehaviour
{
    public int executeDotween = 0;
    public GameObject chargeAttackEffectGameobject;
    public GameObject chargeAttackEffect;
    public float chargeTime = 2f;

    private void Start()
    {
        
    }

    void Update()
    {
        if (executeDotween == 1)
        {
            executeDotween = 0;
            Sequence effectSequence = DOTween.Sequence();
            effectSequence.AppendCallback(() => chargeAttackEffectGameobject.SetActive(true))
                    .Append(chargeAttackEffect.transform.DOScaleY(1, chargeTime).SetEase(Ease.Linear));
        }
        else if (executeDotween == 2)
        {
            executeDotween = 0;
            Debug.Log("Reversing DOTween Sequence");
            chargeAttackEffectGameobject.SetActive(false);
            chargeAttackEffect.transform.DOScaleY (0, 0);
        }
    }
}
