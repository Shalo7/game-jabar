using UnityEngine;
using DG.Tweening;

public class CongklakAnimasi : MonoBehaviour
{
    [Header("Posisi dan Timing")]
    public Vector2 startPosition;
    public Vector2 targetPosition;
    public float animationDuration = 1f;
    public float animationDelay = 0f;

    [Header("Easing / Style")]
    public Ease animationEase = Ease.OutBack;

    private RectTransform rectTransform;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = startPosition;
        gameObject.SetActive(false); // pastikan tidak tampil dulu
    }

    public void ShowCongklakMenu()
    {
        gameObject.SetActive(true);
        rectTransform.anchoredPosition = startPosition;

        rectTransform.DOAnchorPos(targetPosition, animationDuration)
            .SetDelay(animationDelay)
            .SetEase(animationEase);
    }

    public void HideCongklakMenu()
    {
        rectTransform.DOAnchorPos(startPosition, animationDuration)
            .SetEase(animationEase)
            .OnComplete(() => gameObject.SetActive(false));
    }
}
