using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour
{
    private const float SECONDS_TO_POLL_FOR = 5.0f;
    
    private Gyroscope gyro;
    private Vector3 upVector;


    // Use this for initialization
    void Start()
    {
        // init gyro
        gyro = Input.gyro;

        // set pivot point to hilt, based on phone orientation
        
    }

    // Update is called once per frame
    void Update()
    {
        Pivot();
    }

    // Calibration function
    // returns true if the calibration was a success, false if need to
    // calibrate again.
    bool CalibrateExtend()
    {
        // poll the gyroscope for 5 seconds
        for (float secondsLeft = SECONDS_TO_POLL_FOR; secondsLeft > 0.0f;
            secondsLeft -= Time.deltaTime)
        {

        }
        // determine up vector (invert average of all gravity vectors)


        // if there is too much jitter, return false (need to calibrate again) 


        return false;
    }

    bool Calibrate90Degree()
    {
        return false;
    }

    // get and set orientation based gyro
    void Pivot()
    {
        // dump data from gyro straight to weapon (rotation, orientation)

        // set transform to hilt

        // set acceleration
    }

    // handle sword hitting enemies
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "")
        {
            // destroy enemy? play sound? logic needed.
        }
    }
}
