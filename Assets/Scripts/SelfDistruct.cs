using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDistruct : MonoBehaviour {

    [SerializeField] [Tooltip("Destroy delay time, s")] float destroyDelay = 3f;

	void Start ()
    {
        Destroy(gameObject, destroyDelay);
	}

}
