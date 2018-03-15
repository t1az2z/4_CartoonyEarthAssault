using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {

    [SerializeField][Tooltip("Delay befor level load")] float levelLoadDelay = 1f;
    [SerializeField][Tooltip("Reference to death effect game object")] GameObject deathFX;
    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        SendMessage("DisableControlls");
        deathFX.SetActive(true);
        Invoke("ReloadLevel", levelLoadDelay); //string referenced
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}