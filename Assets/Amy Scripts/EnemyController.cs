using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float secondsPerDirection;
    public int randomToLookRatio; // 5 would mean: 4 intervals random, then 1 interval look, 0 1 2 3 4 0 1 2 3 4
    public float speedMultiplier;

    private float secondsSoFar;
    private int intervalSoFar;
    private Vector2 currDirection;

    private Rigidbody2D thisRigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        secondsSoFar = 0;
        intervalSoFar = 0;

        thisRigidBody2D = GetComponent<Rigidbody2D>();
    }

    float QuickRandomHelper()
    {
        return Random.Range(-1.0f, 1.0f); // TOOD: use 0 to 360 and get sin cos
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (secondsSoFar == 0 || secondsSoFar > secondsPerDirection)
        { // time to change direction
            secondsSoFar = 0;
            intervalSoFar = (intervalSoFar + 1) % randomToLookRatio;

            if (intervalSoFar == 0) // look direction 
            {
                // UnityEngine.Debug.Log("Using look direction");

                currDirection = (GameUIController.instance.GetPlayerPosition() - transform.position).normalized;

                // UnityEngine.Debug.Log("player: " + GameUIController.instance.GetPlayerPosition());
                // UnityEngine.Debug.Log("self: " + transform.position);
                // UnityEngine.Debug.Log("diff: " + currDirection);
            }
            else // random direction
            {
                // UnityEngine.Debug.Log("Using random direction");
                currDirection = new Vector3(QuickRandomHelper(), QuickRandomHelper(), 0).normalized;
            }
        }
        else
        {
            Vector2 position = thisRigidBody2D.position;
            position.x = position.x + currDirection.x * speedMultiplier * Time.deltaTime;
            position.y = position.y + currDirection.y * speedMultiplier * Time.deltaTime;
            thisRigidBody2D.MovePosition(position);
        }

        secondsSoFar += Time.deltaTime;
    }
}
