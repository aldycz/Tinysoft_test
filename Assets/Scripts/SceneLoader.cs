using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneName;  // N�zev sc�ny k na�ten�

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);  // Na�te danou sc�nu
    }
}
