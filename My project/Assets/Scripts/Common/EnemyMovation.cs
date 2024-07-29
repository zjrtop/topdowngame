using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovation : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 moveDirection = Vector2.zero;
    public float moveSpeed = 100.0f;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        Vector3 moveVector = moveDirection * moveSpeed * Time.deltaTime;
        float sumVelocity = moveVector.magnitude;
        rb2d.velocity = new Vector2(moveVector.x, moveVector.y);

    }
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject colliderObj = other.gameObject;
        if (!colliderObj.CompareTag("humanbody"))
        {

            moveDirection = -moveDirection;

            Vector3 moveVector = moveDirection * moveSpeed * Time.deltaTime;

            float sumVelocity = moveVector.magnitude;



            rb2d.velocity = new Vector2(moveVector.x, moveVector.y);
            // int faceDir = (int)transform.localScale.x;
            // if (sumVelocity != 0)
            // {

            //     if (moveDirection.x > 0)
            //     {
            //         faceDir = 1;
            //     }
            //     if (moveDirection.x < 0)
            //     {
            //         faceDir = -1;
            //     }
            //     transform.localScale = new Vector3(faceDir, 1, 1);

            
            // }
        }else{
            //触发死亡
             PlayerStates playerStates = colliderObj.GetComponentInParent<PlayerStates>();
            PlayerAnimation parentAnimtionCtl = colliderObj.GetComponentInParent<PlayerAnimation>();
            int sheild = playerStates.GetDetectTimes();
            if(sheild == 1)
            {
                playerStates.DecreaseShield();
                Debug.Log("Sheild Consumer");
            }
            else
            {
                if (parentAnimtionCtl)
                {
                    parentAnimtionCtl.PlayerDeath();
                }
                Debug.Log("Player death");
                PlayerTeleport playerTeleport = colliderObj.GetComponentInParent<PlayerTeleport>();
                if (playerTeleport != null)
                {
                    playerTeleport.Teleport();
                }
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Trigger exited with " + other.gameObject.name);
    }
    // Update is called once per frame

}
