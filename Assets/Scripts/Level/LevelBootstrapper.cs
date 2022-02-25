using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelBootstrapper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        if (!SceneManager.GetSceneByName("Management Scene").isLoaded) {
            SceneManager.LoadScene("Management Scene", LoadSceneMode.Additive);
        }
        if (!SceneManager.GetSceneByName("UI Scene").isLoaded) {
            SceneManager.LoadScene("UI Scene", LoadSceneMode.Additive);
        }
    }
}
