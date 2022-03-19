using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopDownController : MonoBehaviour
{
    public Rigidbody2D body;

    public SpriteRenderer SpriteRenderer;

    public float walkSpeed;

    private Vector2 movement;

    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        body.MovePosition(body.position + movement * walkSpeed * Time.fixedDeltaTime);
    }
}
