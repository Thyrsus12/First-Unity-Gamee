using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public float velocity;
    public float jumpStrength;
    public LayerMask floorLayer;
    public int maxJumps;

    private bool lookingRight = false;
    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider;
    private Animator animator;
    private int remainingJumps;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(remainingJumps + "helllo");
        MovementProcessor();
        JumpProcessor();
        AtackProcessor();
    }

    bool IsOnFloor()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.1f, floorLayer);
        return raycastHit.collider != null;
    }

    void AtackProcessor()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            animator.SetBool("isAtcking", true);
        }
        else
        {
            animator.SetBool("isAtcking", false);
        }
    }

    void JumpProcessor()
    {

        if (IsOnFloor())
        {
            remainingJumps = maxJumps;
            animator.SetBool("isJumping", false);
        }
        else
        {
            animator.SetBool("isJumping", true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && (remainingJumps > 0))
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0f);
            rigidBody.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
            remainingJumps--;
            Debug.Log(remainingJumps);
        }
    }

    void MovementProcessor()
    {
        float movementInput = Input.GetAxis("Horizontal");
        rigidBody.velocity = new Vector2(movementInput * velocity, rigidBody.velocity.y);
        OrientationManager(movementInput);
    }

    void OrientationManager(float movementInput)
    {
        if (lookingRight == true && movementInput < 0 || (lookingRight == false && movementInput > 0))
        {
            lookingRight = !lookingRight;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
}
