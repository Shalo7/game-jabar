using UnityEngine;
using DG.Tweening;

public class TaliAnimasi : MonoBehaviour
{
    [Header("Transform Control")]
    public Vector3 startPosition;
    public Vector3 targetPosition;
    public float startRotationZ = 180f;
    public float targetRotationZ = 0f;

    [Header("Animation Timing")]
    public float duration = 1f;
    public float delay = 0f;
    public Ease easeType = Ease.OutBack;

    private RectTransform rectTransform;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition3D = startPosition;
        rectTransform.localRotation = Quaternion.Euler(0, 0, startRotationZ);
        gameObject.SetActive(false);
    }

    public void AnimateTali()
    {
        gameObject.SetActive(true);
        rectTransform.anchoredPosition3D = startPosition;
        rectTransform.localRotation = Quaternion.Euler(0, 0, startRotationZ);

        Sequence taliAnim = DOTween.Sequence();
        taliAnim.Append(rectTransform.DOLocalRotate(new Vector3(0, 0, targetRotationZ), duration).SetEase(easeType));
        taliAnim.Join(rectTransform.DOAnchorPos3D(targetPosition, duration).SetEase(easeType).SetDelay(delay));
    }
}
