using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private string attackAnim = "PlayerAttack";
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

    public void PlayAttack()
    {
        if (attackAnim.Length != 0)
        {
            anim.Play(attackAnim, 0, 1.0f);
        }
    }

}
