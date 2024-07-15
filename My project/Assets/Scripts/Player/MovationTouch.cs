using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovationTouch : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 10.0f;

    public JoyContainer jsMovement;
    private Rigidbody2D rb2d;
    private float sumVelocity;
    private SpriteRenderer spriteRender;
    private Vector3 direction;
    //private float xMin, xMax, yMin, yMax;


    public float GetVelocity()
    {
        return sumVelocity;
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRender = GetComponent<SpriteRenderer>();
        //Initialization of boundaries
        //xMax = 15 - 8; // I used 50 because the size of player is 100*100
        //xMin = 0;
        //yMax = 15 - 8;
        //yMin = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        MoveControl();
    }

    private void MoveControl()
    {
        direction = jsMovement.InputDirection; //InputDirection can be used as per the need of your project

        Vector3 moveVector = direction * moveSpeed * Time.deltaTime;

        sumVelocity = moveVector.magnitude;

        rb2d.velocity = new Vector2(moveVector.x, moveVector.y);
        if (direction.magnitude != 0)
        {

            bool bIsFlip = spriteRender.flipX;
            if (moveVector.x < 0)
            {
                bIsFlip = true;
            }
            if (moveVector.x > 0)
            {
                bIsFlip = false;
            }
            spriteRender.flipX = bIsFlip;
            //transform.position = new Vector3(Mathf.Clamp(transform.position.x, xMin, xMax), Mathf.Clamp(transform.position.y, yMin, yMax), 0f);//to restric movement of player
        }
    }
}
