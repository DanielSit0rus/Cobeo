using System.Collections;
using System.Collections.Generic;
using System.Security;
using JetBrains.Annotations;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{

    public Transform cardParent;
    public GameObject[] foundationsPrefabs;
    public GameObject[] changePrefabs;
    public GameObject[] dynamicsPrefabs;
    public GameObject[] riskPrefabs;

    private bool cardShown = false;
    GameObject[] selectedPrebabs = null;

    public void spawnCards(string tag)
    {
        

        switch (tag)
        {
            case "Foundations":
                selectedPrebabs = foundationsPrefabs;
                break;
            case "Dynamics":
                selectedPrebabs = dynamicsPrefabs;
                break;
            case "Risk":
                selectedPrebabs = riskPrefabs;
                break;
            case "Change":
                selectedPrebabs = changePrefabs;
                break;

        }

        if(selectedPrebabs != null)
        {
           foreach (GameObject prefab in selectedPrebabs)
            {
                GameObject instantiatedCard = Instantiate(prefab, cardParent);
                RectTransform rectTransform = instantiatedCard.GetComponent<RectTransform>();
                rectTransform.localScale = Vector3.one; // Reset scale to ensure it displays correctly
                rectTransform.localPosition = Vector3.zero; // Reset position within its parent
                rectTransform.localRotation = Quaternion.identity; // Reset rotation to ensure it displays correctly
            }
        }
        }


}

    

