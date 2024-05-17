using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMovement : MonoBehaviour
{
    
    public float velocity;
    private bool lookingRight = false;
    public float jumpStrength;
    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider;
    public LayerMask floorLayer;
    private Animator animator;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementProcessor();   
    }

    void MovementProcessor()
    {
        float movementInput = Input.GetAxis("Horizontal");
        rigidBody.velocity = new Vector2(movementInput * velocity, rigidBody.velocity.y + 0.001f);
    }
}
