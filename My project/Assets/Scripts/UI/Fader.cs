using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Fader : MonoBehaviour
{
    public static Fader Instance { get; private set; }

    public CanvasGroup faderGroup;

    public float fadeDuration = 1.0f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }else if(Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public IEnumerator FaderSceneIn()
    {
        yield return StartCoroutine(Fade(0f, faderGroup));
        faderGroup.gameObject.SetActive(false);
    }
    public IEnumerator FadeSceneOut()
    {
        faderGroup.gameObject.SetActive(true);
        yield return StartCoroutine(Fade(1f, faderGroup));

    }

    public IEnumerator Fade(float finalAlpha, CanvasGroup canvas)
    {
        yield return canvas.DOFade(finalAlpha, fadeDuration).WaitForCompletion(); ;
    }


}
