using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public float Speed = 0;

    private Rigidbody2D _rigidbody2D;
    private Transform _transform;

    public Vector3 Pos => _transform.position;

    void Awake()
    {
        _transform = transform;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _rigidbody2D.AddForce(new Vector2(horizontal, vertical) * Speed);
    }
}
