using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private MovationTouch movation;
    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();
        movation = GetComponent<MovationTouch>();
    }

    public void Update()
    {
        anim.SetFloat("velocity", movation.GetVelocity());
    }
}
