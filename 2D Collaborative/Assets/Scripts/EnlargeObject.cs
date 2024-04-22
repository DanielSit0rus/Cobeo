using UnityEngine;
using UnityEngine.EventSystems; // Required for event handling on UI elements
using UnityEngine.UI; // Required for UI components

public class EnlargeObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 originalScale;
    public float enlargementFactor = 1.2f;

    void Start()
    {
        originalScale = transform.localScale; // Store the original scale
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = originalScale * enlargementFactor; // Enlarge the object
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = originalScale; // Return to original scale
    }
}
