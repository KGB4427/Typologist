using UnityEngine;

public class SwitchScreen : MonoBehaviour
{
    public GameObject canvasA;
    public GameObject canvasB;

    // This function is called when the button is clicked
    public void SwitchScreens()
    {
        canvasA.SetActive(false);
        canvasB.SetActive(true);
    }
}
