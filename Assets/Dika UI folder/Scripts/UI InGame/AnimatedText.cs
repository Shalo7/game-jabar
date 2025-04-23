using UnityEngine;
using DG.Tweening;  // Pastikan DOTween sudah di-import

public class AnimatedText : MonoBehaviour
{
    public GameObject[] textImages;  // Array untuk gambar yang ingin dianimasikan
    public float animationDuration = 0.5f;  // Durasi animasi per gambar
    public float delayBetweenAnimations = 0.3f;  // Delay antar gambar

    void Start()
    {
        // Pastikan semua gambar dimulai dalam keadaan transparan
        foreach (var image in textImages)
        {
            image.GetComponent<CanvasGroup>().alpha = 0;  // Menggunakan CanvasGroup untuk mengatur transparansi
        }

        // Mulai animasi urutan gambar
        AnimateText();
    }

    void AnimateText()
    {
        // Animasi setiap gambar secara berurutan
        for (int i = 0; i < textImages.Length; i++)
        {
            // Mengatur delay untuk setiap animasi
            int index = i;  // Untuk referensi dalam lambda
            DOVirtual.DelayedCall(i * delayBetweenAnimations, () =>
            {
                // Menampilkan gambar dengan animasi fade-in
                textImages[index].GetComponent<CanvasGroup>().DOFade(1, animationDuration).SetEase(Ease.InOutQuad);
            });
        }
    }
}
