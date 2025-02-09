using System.Collections;
using System.Collections.Generic;
using Minifantasy;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public string attackAnim = "PlayerAttack";
    public string deathAnim = "Disappear";
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
        if (anim != null)
        anim.SetInteger("walkingStates", movation.GetFaceDir());
    }

    public void PlayAttack()
    {
        if (attackAnim.Length != 0 && anim != null)
        {
            anim.Play(attackAnim, 0, 1.0f);
        }
    }

    public void PlayerDeath()
    {
        if (attackAnim.Length != 0 && anim != null)
        {
            anim.Play(deathAnim, 0, 1.0f);
        }
    }

    public void SetAnimationRate(string clipName, int sampleRate){
         if (anim != null && !string.IsNullOrEmpty(clipName))
        {
            AnimationClip clip = GetAnimationClipByName(anim, clipName);
            if (clip != null)
            {
                Debug.Log($"Animation clip found: {clip.name}");
                clip.frameRate = sampleRate;                     //设置sample rate;
            }
            else
            {
                Debug.LogWarning("Animation clip not found");
            }
        }
        else
        {
            Debug.LogWarning("Animator or clipName is not set");
        }
    }




    AnimationClip GetAnimationClipByName(Animator animator, string clipName)
    {
        var runtimeAnimatorController = animator.runtimeAnimatorController;
        if (runtimeAnimatorController != null)
        {
            foreach (var clip in runtimeAnimatorController.animationClips)
            {
                if (clip.name == clipName)
                {
                    return clip;
                }
            }
        }
        return null;
    }

}
