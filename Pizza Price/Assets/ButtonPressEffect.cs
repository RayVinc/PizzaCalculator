using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonPressEffect : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Vector3 originalScale;
    private float scaleFactor = 0.95f; // Adjust as needed

    void Start()
    {
        originalScale = transform.localScale;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.localScale = originalScale * scaleFactor;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localScale = originalScale;
    }
}
