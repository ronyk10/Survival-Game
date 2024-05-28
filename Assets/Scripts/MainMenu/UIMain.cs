using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMain : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1); // Load the scene with build index 1
    }

    public void QuitGame()
    {
        Application.Quit(); // Quits the game (only works in build)

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Exits play mode (will only be executed in the editor)
#endif
    }
}
