using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    // Start is called before the first frame update

    public int progress;
    Vector3 position = Vector3.zero;
    Rigidbody2D rb;

    void Start()
    {
        progress = GameInstance.Instance.progress;
        if (progress == 0)
        {
            position = new Vector3();
        }
        else if (progress == 1)
        {
            position = new Vector3();
        }
        else if (progress == 2) {
            position = new Vector3();
        }
        rb = GetComponent<Rigidbody2D>();
    }

    public void Teleport()
    {
        Vector3 destination = position;

        if (rb != null)
        {
            rb.isKinematic = true;
        }

        transform.position = destination;

        if (rb != null)
        {
            rb.isKinematic = false;
        }

        Debug.Log("玩家已瞬移到位置：" + destination);
    }
}
