using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    Vector3 healthScale;
    public float scale = 1;
    // Start is called before the first frame update
    void Start()
    {
        healthScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tempScale = healthScale;
        tempScale.x *= scale;
        transform.localScale = tempScale;
        Debug.Log("SCALE:" + scale);
    }
}
