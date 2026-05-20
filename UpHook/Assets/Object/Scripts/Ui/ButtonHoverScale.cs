using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHoverScale : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button targetButton; // назначьте кнопку в редакторе или получите её автоматически
    public float scaleFactor = 1.2f; // коэффициент увеличения
    private Vector3 originalScale;

    void Start()
    {
        if (targetButton == null)
        {
            targetButton = GetComponent<Button>();
        }
        originalScale = targetButton.transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        targetButton.transform.localScale = originalScale * scaleFactor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        targetButton.transform.localScale = originalScale;
    }
}