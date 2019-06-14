using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    Wander,
    Follow,
    Die
};
public class EnemyMeeleAI : MonoBehaviour
{
    GameObject player;
    public EnemyState currentState = EnemyState.Wander;
    public float range, speed;
    private bool chooseDir=false, dead=false;
    private Vector3 randomDir;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case EnemyState.Wander:
                wander();
                break;
            case EnemyState.Follow:
                follow();
                break;
            case EnemyState.Die:
                die();
                break;
            default:
                Debug.LogError("ENEMY BAD STATE!");
                break;
        }

        if(isPlayerInRange() && currentState != EnemyState.Die)
        {
            currentState = EnemyState.Follow;
        }
        else if(!isPlayerInRange() && currentState != EnemyState.Die)
        {
            currentState = EnemyState.Wander;
        }
    }

    private bool isPlayerInRange()
    {  return Vector3.Distance(transform.position, player.transform.position) <= range; }

    private IEnumerator chooseDirection()
    {
        chooseDir = true;
        yield return new WaitForSeconds(Random.Range(2f, 8f));
        randomDir = new Vector3(0, 0, Random.Range(0f, 360f));
        Quaternion nextRotation = Quaternion.Euler(randomDir);
        transform.rotation = Quaternion.Lerp(transform.rotation, nextRotation, Random.Range(0.5f, 2.5f));
        chooseDir = false;
    }

    private void wander()
    {
        if(!chooseDir)
        {
            StartCoroutine(chooseDirection());
        }

        transform.position += -transform.right * speed * Time.deltaTime;
        if(isPlayerInRange())
        {
            currentState = EnemyState.Follow;
        }
    }
    
    private void follow()
    {
        Vector3 target = player.transform.position - transform.position;
        float angle = Mathf.Atan2(target.x, target.y)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 180, Vector3.forward);
        transform.position += -transform.right * speed * Time.deltaTime;

        //transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void die()
    {

    }
}
