using UnityEngine;
using UnityEngine.UI;

public static class Extensions
{
    public static void Open(this CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.gameObject.SetActive(true);
    }

    public static void Close(this CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.gameObject.SetActive(false);
    }

    public static void Inactive(this CanvasGroup canvasGroup)
    {
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    public static void SetImage(this Button button, bool isPlay)
    {
        Image image = button.GetComponent<Image>();
        if (isPlay)
        {
            image.color = new Color(
                image.color.r,
                image.color.g,
                image.color.b,
                1f);
        }
        else
        {
            image.color = new Color(
                image.color.r,
                image.color.g,
                image.color.b,
                0.5f);
        }
    }
}
