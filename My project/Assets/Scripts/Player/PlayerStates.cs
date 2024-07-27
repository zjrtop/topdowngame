using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    private int detectTimes = 0;

    public bool bIsTalkWithMerchant = false;





    public void IncrementShield() {
        detectTimes =  1;
    }

    public void DecreaseShield() {
        detectTimes = 0;
    }

    public int GetDetectTimes() {
        return detectTimes;
    }

}
