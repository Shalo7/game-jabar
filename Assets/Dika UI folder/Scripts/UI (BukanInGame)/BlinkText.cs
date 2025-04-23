using DG.Tweening;
using UnityEngine;

public class BlinkText : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float blinkSpeed = 1f;

    void Start()
    {
        if (canvasGroup == null)
            canvasGroup = GetComponent<CanvasGroup>();

        Blink();
    }

    void Blink()
    {
        canvasGroup.DOFade(0f, blinkSpeed / 2f).SetLoops(-1, LoopType.Yoyo);
    }
}
