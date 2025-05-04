using UnityEngine;
using UnityEngine.UI;

public class ButtonActivator : MonoBehaviour
{
    public GameObject targetObject;     // The object you want to check if it's active
    public Button buttonToControl;      // The UI button you want to enable/disable

    void Update()
    {
        // If targetObject is active in the hierarchy, enable the button
        if (targetObject != null && buttonToControl != null)
        {
            buttonToControl.interactable = targetObject.activeInHierarchy;
        }
    }
}
