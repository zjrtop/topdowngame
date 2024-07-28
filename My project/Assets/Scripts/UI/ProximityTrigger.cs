using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityTrigger : MonoBehaviour
{
    private bool isPlayerNearby = false; // 用于记录玩家是否在附近

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true; // 设置玩家在附近
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false; // 设置玩家不在附近
        }
    }

    public bool GetIsPlayerNearby()
    {
        return isPlayerNearby;
    }
}