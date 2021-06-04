using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float startWaitTime;
    private float waitTime;
    public float distance;
    public float stoppingDistance;
    public float rotationSpeed;

    public Transform[] moveSpots;
    private int randomSpot;

    private Transform target;

    Alert alert;

    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);

        Physics2D.queriesStartInColliders = false;
    }

    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance);
        if (hitInfo.collider != null)
        {
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);

            // if ray has hit player
            if (hitInfo.collider.CompareTag("Player"))
            {
                // will target the player
                target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

                // will rotate towards the player
                transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

               
            }
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green);
        }


        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 5f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    

    private void OnCollisionEnter(Collision other)
    {
        alert = other.gameObject.GetComponent<Alert>();
        alert.Targeted += Follow;
    }

    void Follow()
    {
        // will target the player
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        // will rotate towards the player
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}

