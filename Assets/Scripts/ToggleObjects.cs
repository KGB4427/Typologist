using UnityEngine;

public class ToggleObjects : MonoBehaviour
{
    public GameObject objectToDisable;
    public GameObject objectToEnable;

    public void ToggleObjectsUpdate()
    {
        if (objectToDisable != null)
            objectToDisable.SetActive(false);

        if (objectToEnable != null)
            objectToEnable.SetActive(true);
    }
}