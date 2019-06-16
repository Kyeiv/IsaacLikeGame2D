using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    private Transform moveSpot;
    //private int randomSpot;
    private float minX;
    private float maxX;
    private float minY;
    private float maxY;


    // Start is called before the first frame update
    public void Start()
    {
        minX = transform.position.x - 100;
        maxX = transform.position.x + 100;
        minY = transform.position.y - 40;
        maxY = transform.position.y + 40;
        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    // Update is called once per frame
    public void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpot.position)<0.2f)
        {
            moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        }
    }
}
