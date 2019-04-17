using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFader : MonoBehaviour { 

    Animator anim;
    bool isFading = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public IEnumerator FadeToClear() {
        isFading = true;
        anim.SetTrigger("Visible");

        while (isFading) {
            yield return null;
        }
    }

    public IEnumerator FadeToBlack()
    {
        isFading = true;
        anim.SetTrigger("Unvisibe");

        while (isFading)
        {
            yield return null;
        }
    }

     void AnimationComplete() {
        isFading = false;
    }
}
