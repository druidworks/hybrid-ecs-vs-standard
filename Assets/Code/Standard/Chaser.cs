using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour {
    public float speed = 1f;
    public float maxSpeed = 50f;

    private GameObject player;
    private Rigidbody rb;

    private void Start()
    {
        player = GameManager.GetPlayerInstance();
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = maxSpeed / 2;
    }

    private void Update()
    {
        var time = Time.deltaTime;
        if (!player)
        {
            player = GameManager.GetPlayerInstance();
        }

        if (!rb) return;

        Chase();        
    }

    private void Chase()
    {
        Vector3 moveDirection = (player.transform.position - transform.position).normalized;
        rb.AddTorque(new Vector3(moveDirection.z, 0, -moveDirection.x) * speed);
    }
}
