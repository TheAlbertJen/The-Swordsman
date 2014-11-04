using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour
{
    private const float SECONDS_TO_POLL_FOR = 3.0f;
    
    private Gyroscope gyro;
    private Vector3 upVector;


    // Use this for initialization
    void Start()
    {
        // set screen orientation so axes don't change with movement
        Screen.orientation = ScreenOrientation.Portrait;

        // init gyro
        gyro = Input.gyro;

    }

    // Update is called once per frame
    void Update()
    {
        Pivot();
    }

    // Calibration function
    // returns true if the calibration was a success, false if need to
    // calibrate again.
    bool CalibrateGyro()
    {
        // vectors for calibrating
        Vector3 sumGravity = new Vector3(0, 0, 0);
        uint numGravityVectors = 0;

        // poll the gyroscope
        for (float secondsLeft = SECONDS_TO_POLL_FOR; secondsLeft > 0.0f;
            secondsLeft -= Time.deltaTime)
        {
            sumGravity += gyro.gravity.normalized;
            numGravityVectors++;
        }
        // determine up vector (invert average of all gravity vectors)
        Vector3 averageGravity = sumGravity / numGravityVectors;
        Vector3 upVector = averageGravity.normalized * -1;

        // TODO: play sound to signal end of calibration

        Handheld.Vibrate();

        // if there is too much jitter, return false (need to calibrate again), 
        // how to determine too much jitter?

        return false;
    }

    // get and set orientation based gyro
    void Pivot()
    {
        // dump data from gyro straight to weapon (rotation, orientation)
        this.transform.rotation = gyro.attitude;

        // determine new location of weapon
        Vector3 deviceAccel = gyro.userAcceleration;
        float timeElapsed = Time.deltaTime;
        // initial vel = 0.0f?
        Vector3 disp = 0.5f * deviceAccel * timeElapsed * timeElapsed;
        this.gameObject.transform.position += disp;
    }


}
