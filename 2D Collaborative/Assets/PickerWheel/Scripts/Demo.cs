using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyUI.PickerWheelUI;
using UnityEngine.UI;
using TMPro;

public class Demo : MonoBehaviour
    

{
    [SerializeField] private Button spinButton;
    [SerializeField] private TMP_Text spinButtonText;

    [SerializeField] private PickerWheel pickerWheel;





    // Start is called before the first frame update
    void Start()
    {
        spinButton.onClick.AddListener(() =>
        {
            spinButton.interactable = false;
            spinButtonText.text = "Spinning";


            pickerWheel.OnSpinStart(() =>
            {
                Debug.Log("Spin Started...");
            });
            pickerWheel.OnSpinEnd(WheelPiece =>
            {
                Debug.Log("Spin end: Label:" + WheelPiece.Label + " , Amount:" + WheelPiece.Amount);
                spinButtonText.text = "Spin";

                spinButton.interactable = true;
            });
            pickerWheel.Spin();
        }); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
