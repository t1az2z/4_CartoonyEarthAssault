using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    //todo change circuit to depend from Time.deltaTime

    [Header("General")]
    [SerializeField] GameObject[] guns;

    [Tooltip("In ms^-1 (meters per second)")][SerializeField] float controllSpeed = 60f;
    [Tooltip("in meters")][SerializeField] float xRange = 28f;
    [Tooltip("in meters")] [SerializeField] float yRange = 22f;

    [Header("Screen-position parameters")]
    [SerializeField] float positionPitchFactor = -.8f;
    [SerializeField] float positionYawFactor = .8f;

    [Header("Controll-throw parameters")]
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float controllRollFactor = -25;
    float xThrow, yThrow;

    bool controllsEnabled = true;

	void Update ()
    {
        if (controllsEnabled)
        {
            ProcessTransition();
            ProcessRotation();
            ProcessFiring();
        }


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
        float xOffset = xThrow * controllSpeed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        //Vertical movement
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * controllSpeed * Time.deltaTime;

        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);


        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            ActivateGuns();
        }
        else
        {
            DeactivateGuns();
        }
    }

    private void DeactivateGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(false);
        }
    }

    private void ActivateGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(true);
        }
    }

    private void DisableControlls() //called by string reference
    {
        controllsEnabled = false;
    }


}
