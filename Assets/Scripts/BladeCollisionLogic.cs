using UnityEngine;
using System.Collections;

public class BladeCollisionLogic : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // handle sword hitting enemies
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "")
        {
            // destroy enemy? play sound? logic needed.
        }
    }
}
