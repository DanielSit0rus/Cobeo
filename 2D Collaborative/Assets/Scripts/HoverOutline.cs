using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverOutline : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Material outlineMaterial;
    private Material originalMaterial;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Check if spriteRenderer is null
        if (spriteRenderer == null)
        {
            Debug.Log("SpriteRenderer component not found on the object.");
        }

        // Check if outlineMaterial is null
        if (outlineMaterial == null)
        {
            Debug.Log("Outline Material has not been assigned in the Inspector.");
        }
    }

    void OnMouseEnter()
    {
        if (spriteRenderer != null && outlineMaterial != null)
        {
            spriteRenderer.material = outlineMaterial;
        }
    }

    void OnMouseExit()
    {
        if (spriteRenderer != null)
        {
            // Assuming you want to revert to the original material
            spriteRenderer.material = originalMaterial;
        }
    }
}
