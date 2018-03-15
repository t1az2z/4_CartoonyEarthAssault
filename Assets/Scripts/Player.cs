using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [Tooltip("In ms^-1 (meters per second)")][SerializeField] float speed = 60f;
    [Tooltip("in meters")][SerializeField] float xRange = 28f;
    [Tooltip("in meters")] [SerializeField] float yRange = 22f;

    [SerializeField] float positionPitchFactor = -.8f;
    [SerializeField] float controlPitchFactor = -20f;


    [SerializeField] float positionYawFactor = .8f;


    [SerializeField] float controllRollFactor = -25;
    float xThrow, yThrow;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        ProcessTransition();
        ProcessRotation();


    }

    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControllThrow = yThrow *controlPitchFactor;
        float pitch = pitchDueToControllThrow + pitchDueToPosition;

        float yawDueToPosition = transform.localPosition.x * positionYawFactor;
        float yaw = yawDueToPosition;

        float rollToControllThrow = xThrow * controllRollFactor;
        float roll = rollToControllThrow;
        

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTransition()
    {
        //Horizontal movement
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * speed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        //Vertical movement
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * speed * Time.deltaTime;

        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);


        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            print("enemy hit");
        }
        else
        {
            print("triggered");
        }
    }


}
