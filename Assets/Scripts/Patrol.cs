using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float startWaitTime;
    private float waitTime;
    public float rotationSpeed = 30;

    public Transform[] moveSpots;
    private int randomSpot;

    // Variables for Chasing
    private Transform target;
    public float stoppingDistance;

    void Start() {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
        // target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update() {

        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        // transform.Rotate(Vector3.forward, )

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f){
            if (waitTime <= 0){
                waitTime = startWaitTime;
                randomSpot = Random.Range(0, moveSpots.Length);
            } else {
                waitTime -= Time.deltaTime;
            }
        }
    }


}
