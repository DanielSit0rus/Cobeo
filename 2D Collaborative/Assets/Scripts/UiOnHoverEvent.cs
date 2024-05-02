using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiOnHoverEvent : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Vector3 cachedScale;
    private bool isRightClicked = false;

    void Start()
    {
        cachedScale = transform.localScale; // Cache the initial scale
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Check if the right mouse button was clicked
        if (eventData.button == PointerEventData.InputButton.Right)
        {


            transform.localScale = new Vector3(4, 4, 4); // Enlarge the object
            isRightClicked = true; // Set the flag
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // If it was right-clicked, then reset the scale when the right mouse button is released
        if (isRightClicked && eventData.button == PointerEventData.InputButton.Right)
        {
            transform.localScale = cachedScale; // Reset to original scale
            isRightClicked = false; // Reset the flag
        }
    }
}
