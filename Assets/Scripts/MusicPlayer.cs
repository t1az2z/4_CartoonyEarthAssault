using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start () {
        Invoke("LoadFirstScene", 5f);

	}
    void LoadFirstScene()
    {
        SceneManager.LoadScene(1);

    }

    void Update () {
		
	}
}
