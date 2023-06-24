using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoldDetection : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isButtonHeld = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        // Button is pressed down
        isButtonHeld = true;
        Debug.Log("Button Pressed Down");

        // Add your custom code here
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Button is released
        isButtonHeld = false;
        Debug.Log("Button Released");

        // Add your custom code here
    }

    private void Update()
    {
        if (isButtonHeld)
        {
            // Button is being held down
            Debug.Log("Button Held Down");

            // Add your custom code here
        }
    }
}
