using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovationTouch : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 0.001f;

    public JoyContainer jsMovement;

    private float sumVelocity;
    private Vector3 direction;
    private float xMin, xMax, yMin, yMax;


    public float GetVelocity()
    {
        return sumVelocity;
    }

    void Start()
    {
        //Initialization of boundaries
        xMax = 15 - 8; // I used 50 because the size of player is 100*100
        xMin = 0;
        yMax = 15 - 8;
        yMin = 0;
    }

    // Update is called once per frame
    void Update()
    {
        direction = jsMovement.InputDirection; //InputDirection can be used as per the need of your project

        sumVelocity = (direction * moveSpeed).magnitude;

        if (direction.magnitude != 0)
        {

            transform.position += direction * moveSpeed;
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, xMin, xMax), Mathf.Clamp(transform.position.y, yMin, yMax), 0f);//to restric movement of player
        }
    }
}
