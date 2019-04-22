using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour {

    public Transform warpTarget;

    public IEnumerator OnTriggerEnter2D(Collider2D collison)
    {
        ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader> ();

        if (collison.tag != "Bullet") {
            yield return StartCoroutine(sf.FadeToBlack());

            Debug.Log("COLLIDED");
            collison.gameObject.transform.position = warpTarget.position;
            Camera.main.transform.position = warpTarget.position;

            yield return StartCoroutine(sf.FadeToClear());
        }
    }
}
