using UnityEngine;

public class QuitGame : MonoBehaviour
{
    // Set this to whatever key you want to use to quit the game
    public KeyCode quitKey = KeyCode.Escape;

    void Update()
    {
        if (Input.GetKeyDown(quitKey))
        {
            Quit();
        }
    }

    public void Quit()
    {
        #if UNITY_EDITOR
            // Stop playing the scene in the editor
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            // Quit the game
            Application.Quit();
        #endif
    }
}
