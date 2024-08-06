using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeEffect : MonoBehaviour
{
    [SerializeField] float timeToFade = 1f;

    [SerializeField] Image image;

    [SerializeField] Color fadeIn;

    [SerializeField] Color fadeOut;

    public delegate void fadeProccess();

    [SerializeField] bool inFading;

    public bool InFading { get => inFading; }
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        FadeManager.instance.FadeEffect = this;
    }

    public void Fade(fadeProccess fadeProccess, bool In, float timeToWait)
    {
        StopAllCoroutines();

        if (In)
            StartCoroutine(Fading(fadeProccess, fadeOut, fadeIn, timeToWait));
        else
            StartCoroutine(Fading(fadeProccess, fadeIn, fadeOut, timeToWait));

    }

    IEnumerator Fading(fadeProccess fadeProccess, Color from, Color to, float timeToWait)
    {
        yield return new WaitForSecondsRealtime(timeToWait);
        inFading = true;
        float time = 0;
        while (time < timeToFade)
        {
            image.color = Color.Lerp(from, to, time / timeToFade);
            time += Time.deltaTime;
            yield return null;
        }
        image.color = to;
        fadeProccess.Invoke();
        inFading = false;
    }

}
