using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField][Tooltip("Death FX prefab")] GameObject deathFX;
    [SerializeField] [Tooltip("Parrent object for spawned fx prefabs")] Transform fxParrent;

    [SerializeField] int scorePerEnemy = 12;
    [SerializeField] int hits = 3;

    ScoreBoard scoreBoard;

    private void Start()
    {
        AddBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();

    }

    private void AddBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        TakeAHit();
        if (hits <= 0)
        {
            EnemyDeath();
        }

    }

    private void TakeAHit()
    {

        hits--;
        //todo possibly hit effect
    }

    private void EnemyDeath()
    {
        scoreBoard.ScoreHit(scorePerEnemy);
        GameObject fx = Instantiate(deathFX, transform.localPosition, Quaternion.identity); //todo change localPosition to global after enemy remake
        fx.transform.parent = fxParrent;
        Destroy(gameObject);
    }
}
