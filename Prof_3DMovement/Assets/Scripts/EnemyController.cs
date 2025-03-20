using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    Transform playerTran;
    NavMeshAgent myAgent;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        playerTran = GameObject.Find("Player").GetComponent<Transform>();
        myAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        /* //just go straight to a point
        Vector3 step = playerTran.position - transform.position;
        transform.forward = step;
        step = step.normalized;
        transform.position += step * speed * Time.deltaTime;
        */

        myAgent.SetDestination(playerTran.position);

    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject otherGO = collision.gameObject;
        if(otherGO.tag == "BlueBullet") {
            Destroy(gameObject);
        }
    }

}
