using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour
{
    
    // Use this for initialization
    void Start()
    {
        //set pivot point to hilt, based on phone orientation
    }

    // Update is called once per frame
    void Update()
    {
        Pivot();
    }

    // Calibration function
    // returns true if the calibration was a success, false if need to
    // calibrate again.
    bool Calibrate()
    {
        return false;
    }

    // get and set orientation based on accelerometer
    void Pivot()
    {
        
    }

    // 
}
