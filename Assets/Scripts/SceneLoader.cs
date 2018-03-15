using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    void Start()
    {
        Invoke("LoadFirstScene", 5f);

    }

    void LoadFirstScene()
    {
        SceneManager.LoadScene(1);

    }
}
