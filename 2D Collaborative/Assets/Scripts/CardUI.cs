using UnityEngine;
using UnityEngine.UI; // Import for UI elements
using System.Collections;

public class CardUI : MonoBehaviour
{
    private Image image; // Use Image component for UI

    [SerializeField]
    private Sprite faceSprite, backSprite;
    [SerializeField]
    private Vector3 originalScale;

    private bool coroutineAllowed, facedUp;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>(); // Get the Image component instead of SpriteRenderer
        image.sprite = backSprite; // Assign the back sprite initially
        coroutineAllowed = true;
        facedUp = false;
        originalScale = new Vector3(1.5f, 1.5f, 1);
    }

    public void OnClick() // Public method to call when the card is clicked
    {
        if (coroutineAllowed)
        {
            StartCoroutine(RotateCard());
        }
    }

    private IEnumerator RotateCard()
    {
        coroutineAllowed = false;
        // Determine target sprite based on the current state
        Sprite targetSprite = facedUp ? backSprite : faceSprite;

        // Use originalScale for scaling. Assuming originalScale is already set to (1.5, 1.5, 1) in the Inspector.
        // First half of the flip (scale down width to 0)
        for (float scale = originalScale.x; scale >= 0; scale -= 0.15f) // Adjust scale decrement for smoothness
        {
            image.rectTransform.localScale = new Vector3(scale, originalScale.y, originalScale.z);
            yield return new WaitForSeconds(0.02f);
        }

        // Change the sprite at the halfway point
        image.sprite = targetSprite;

        // Second half of the flip (scale up width from 0 to original scale)
        for (float scale = 0; scale <= originalScale.x; scale += 0.15f) // Match increment with decrement for consistency
        {
            image.rectTransform.localScale = new Vector3(scale, originalScale.y, originalScale.z);
            yield return new WaitForSeconds(0.02f);
        }

        // Explicitly set the scale back to originalScale to ensure it's correct
        image.rectTransform.localScale = originalScale;

        coroutineAllowed = true;
        facedUp = !facedUp; // Update state to reflect the flip
    }

}



