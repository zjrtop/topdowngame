using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
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

    private int face_dir = 0;

    public int GetFaceDir(){
        return face_dir;
    }
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

        //计算移动速度
        direction = jsMovement.InputDirection; //InputDirection can be used as per the need of your project

        Vector3 moveVector = direction * moveSpeed * Time.deltaTime;

        sumVelocity = moveVector.magnitude;

        rb2d.velocity = new Vector2(moveVector.x, moveVector.y);

        // 通过移动状态设置动画标志；
        if (direction.magnitude != 0)
        {
            direction = direction.normalized;
            Vector2 direct2d = new Vector2(direction.x, direction.y); 
            float angle = CalculateClockwiseAngle(direct2d);
            if (angle>=45.0f && angle < 135.0f){        // 上
                face_dir = 4;
            }else if (angle >= 135.0f && angle < 225.0f){    //左
                face_dir = 2;
            }else if(angle >= 225.0f && angle < 315.0f){      //下
                face_dir = 1;
            }else{                                        //右
                face_dir = 3;
            }
            // bool bIsFlip = spriteRender.flipX;
            // if (moveVector.x < 0)
            // {
            //     bIsFlip = true;
            // }
            // if (moveVector.x > 0)
            // {
            //     bIsFlip = false;
            // }
            // spriteRender.flipX = bIsFlip;
            //transform.position = new Vector3(Mathf.Clamp(transform.position.x, xMin, xMax), Mathf.Clamp(transform.position.y, yMin, yMax), 0f);//to restric movement of player
        }else{
            face_dir = 0;
        }
    }

      float CalculateClockwiseAngle(Vector2 vector)
    {
        // 使用 Mathf.Atan2 计算向量的角度
        float angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;

        // 由于 Atan2 返回的是从 x 轴逆时针至向量的角度，调整为顺时针
        if (angle < 0)
        {
            angle += 360;
        }

        // 转换为顺时针方向
        angle = 360 - angle;

        // 确保角度在 0 到 360 度之间
        if (angle >= 360)
        {
            angle -= 360;
        }

        return angle;
    }

}
