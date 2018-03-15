using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] GameObject deathFX;

    private void Start()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        deathFX.SetActive(true);
        Invoke("EnemyDeath", .5f); //string reference
    }
    private void EnemyDeath()
    {
        Destroy(gameObject);
    }
}
