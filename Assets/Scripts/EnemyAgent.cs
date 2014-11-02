using UnityEngine;
using System.Collections;


public class EnemyAgent : MonoBehaviour
{
    private enum AIState { PAUSE = 0, CHARGE, PATH, MOVE, RANDOM };

    // Vars
    public GameObject playerObject;
    private Vector3 targetPosition;
    private float moveSpeed;
    private float dangerZoneProximity;
    private AIState currState;
    private float pauseTimer;

    // Use this for initialization
    void Start()
    {
        // init all variables
        targetPosition = playerObject.transform.position;

        // Speed at which enemy moves at
        moveSpeed = 10.0f;

        // How much to avoid the player by
        dangerZoneProximity = 10.0f;

        // State machine variables
        currState = AIState.PATH; // default state is pathfinding
        pauseTimer = Random.Range(1.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        DoSmarts();
        Move();
    }

    // Main "AI" function
    private void DoSmarts()
    {
        // Determine proper course of action through simple state machine

        Vector3 toPlayer = playerObject.transform.position - this.transform.position;

        if (toPlayer.magnitude < dangerZoneProximity)
            currState = AIState.CHARGE;

        switch (currState)
        {
            default:
            case AIState.PAUSE:
                // do nothing until pause timer is up (idle)
                Pause();
                break;
            case AIState.CHARGE:
                Charge();
                break;
            case AIState.MOVE:
                Move();
                break;
            case AIState.PATH:
                // move slowly to target position? set new target position only?
                Pathfinding();
                break;
        }
    }

    private void Pause()
    {
        // decrease timer by elapsed time
        // if pause timer is up, change state
        pauseTimer -= Time.deltaTime;
        if (pauseTimer <= 0.0f)
            SetState(AIState.RANDOM);
    }

    private void Charge()
    {
        //when charging, speed increases, head straight for player
    }

    // Use current position and target position to determine path without
    // getting too close to the player (danger zone buffering)
    private void Pathfinding()
    {
        Vector3 newTargetPosition = new Vector3();

        // Get player position, used for targeting and for buffering
        Vector3 playerPosition = playerObject.transform.position;

        // Picking next point
        // v = vector from enemy to player
        // d = length of v
        // p = target position
        // p is 0.25d along v from enemy and 0.25d along a vector
        //    perpendicular to v

        Vector3 v = playerPosition - this.transform.position;
        Vector3 vunit = v;
        vunit.Normalize();
        float d = v.magnitude;

        Vector3 p = (0.25f * v) +
            ( (0.25f*d) * Vector3.Cross(vunit, new Vector3(0,1,0)) * // finding perpendicular vector
            Mathf.Pow(-1, Random.Range(1,2))); // random on either side of v

        targetPosition = p;

        // TODO:
        // If target position is too close to player, change logic
        // If target position is where current sword location is, change target


    }

    private void SetState(AIState state)
    {

        if (state == AIState.RANDOM)
            currState = (AIState)(Random.Range(
                (int)AIState.PAUSE, (int)AIState.PATH));
        else
            currState = state;
    }

    public void Move()
    {
        //move
        this.rigidbody.velocity = moveSpeed *
            (targetPosition - this.transform.position);

        //determine step rate
        float stepRate = 1.0f;

        // TODO: Determine step rates for regular moving versus charging
        //       Need to also figure out formula for generating step rate to
        //       PACE & STRIDE to determine frequency of playback and which
        //       sound effect to play

    }

    public void OnDeath()
    {
        // TODO: play sound
        // Tell factory object needs to be destroyed
        // kill object
    }
}
