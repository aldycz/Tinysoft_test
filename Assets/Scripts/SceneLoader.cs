using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneName;  // Název scény k naètení

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);  // Naète danou scénu
    }
}
