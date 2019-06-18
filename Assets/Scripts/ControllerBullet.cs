using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerBullet : MonoBehaviour
{
    public float lifeTime;
    public bool isEnemyBullet;

    private Vector2 lastPos;
    private Vector2 curPos;
    private Vector2 playerPos;
    public int damage = 5;
    public float bulletSpeed = 50f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DeathDelay());
    }

    // Update is called once per frame
    void Update()
    {
        curPos = transform.position;
        transform.position = Vector2.MoveTowards(transform.position, playerPos, bulletSpeed * Time.deltaTime);
        if(curPos == lastPos)
        {
            Destroy(gameObject);
        }
        lastPos = curPos;
    }

    public void GetPlayer(Transform player)
    {
        playerPos = player.position;
    }

    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            //Destroy(gameObject);
            //GetComponent<PlayerHealth>().TakeDamage(damage);

        }
        if (other.gameObject.CompareTag("Nerve") || other.gameObject.CompareTag("Boss"))
        {
            return;
        }
        Destroy(gameObject);
    }
}
