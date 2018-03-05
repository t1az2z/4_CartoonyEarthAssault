using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("LoadFirstScene", 5f);
	}
    void LoadFirstScene()
    {
        SceneManager.LoadScene(1);

    }
    // Update is called once per frame
    void Update () {
		
	}
}
