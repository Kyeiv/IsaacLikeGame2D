using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float seconds;
    // Start is called before the first frame update
    void Start()
    {
        seconds = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;
    }

    public float getTime()
    {
        return seconds;
    }
}
