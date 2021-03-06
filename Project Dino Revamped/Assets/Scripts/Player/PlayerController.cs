using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class PlayerController : MonoBehaviour
{
    // Move player in 2D space
    public float maxSpeed = 7f;
    public float jumpHeight = 6.5f;
    public float gravityScale = 1.5f;
    public Camera mainCamera;
    public float midairVeloDecrease = .8f;
    [SerializeField] public LayerMask whatIsLadder;

    bool facingRight = true;
    float moveDirection = 0;
    bool isGrounded = false;
    public bool isMoving;
    public float horizontalJumpVelocity = 7f;
    // Vector2 cameraPos;
    Rigidbody2D r2d;
    CapsuleCollider2D mainCollider;
    Transform t;
    public float ladderDistance;
    private bool isClimbing;
    private float inputVertical;
    private float inputHorizontal;
    public float climbSpeed = 3f;
    private Vector3 respawnPoint; 
    

   
    void Start()
    {
        t = transform;
        r2d = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<CapsuleCollider2D>();
        r2d.freezeRotation = true;
        r2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        r2d.gravityScale = gravityScale;
        facingRight = t.localScale.x > 0;
        respawnPoint = transform.position;

    //     if (mainCamera)
    //     {
    //         cameraPos = mainCamera.transform.position;
    //     }
     }

    
    void Update()
    {
        
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && (isGrounded || Mathf.Abs(r2d.velocity.x) > 0.01f))
        {
            moveDirection = Input.GetKey(KeyCode.A) ? -1 : 1;
        }
        else
        {
            if (isGrounded || r2d.velocity.magnitude < 0.01f)
            {
                moveDirection = 0;
            }
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) && !isGrounded)
        {
            moveDirection = Input.GetKey(KeyCode.A) ? -1 : 1;
        }

       
        if (moveDirection != 0)
        {
            if (moveDirection > 0 && !facingRight)
            {
                facingRight = true;
                t.localScale = new Vector3(Mathf.Abs(t.localScale.x), t.localScale.y, transform.localScale.z);
            }
            if (moveDirection < 0 && facingRight)
            {
                facingRight = false;
                t.localScale = new Vector3(-Mathf.Abs(t.localScale.x), t.localScale.y, t.localScale.z);
            }
        }

       
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            r2d.velocity = new Vector2(r2d.velocity.x, jumpHeight);
        }

        
        // void OnTriggerEnter2D(Collider2D collision)
        // {
        // GameObject Ladder = collision.gameObject;
        //     if(Ladder.name == "Ladders")
        //     {
        //         Debug.Log("Collided with ladder");
        //         ClimbLadder();
        //     }

        // }
        // void ClimbLadder()
        // {
        //     float inputVertical = Input.GetAxisRaw("Vertical");
        //     if (Input.GetKeyDown(KeyCode.E))
        //     {
                
        //         r2d.velocity = new Vector2(r2d.velocity.x, inputVertical * 10);
        //     }
        // }       

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if(collisionGameObject.name == "Obstacles")
        {
            transform.position = respawnPoint;
        } 
        else if(collision.tag == "Checkpoint" )
        {
            respawnPoint = transform.position;
        }

    }

  
    void FixedUpdate()
    {
        Bounds colliderBounds = mainCollider.bounds;
        float colliderRadius = mainCollider.size.x * 0.4f * Mathf.Abs(transform.localScale.x);
        Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, colliderRadius * 0.9f, 0);
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckPos, colliderRadius);
        
        isGrounded = false;
        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i] != mainCollider)
                {
                    isGrounded = true;
                    break;
                }
            }
        }

        
       if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) < 0.01)
       {
           isMoving = false;
       } else { isMoving = true;}

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, ladderDistance, whatIsLadder);
       
       if(hitInfo.collider != null)
       {
           if(Input.GetKeyDown(KeyCode.W))
           {    Debug.DrawRay(transform.position, transform.forward, Color.green); print("Hit");
               //isGrounded = false;    <- tried to make ladder movement work with holding down a key but its way too much work so fuck that
               isClimbing = true;
           } 
           
       } else {
           isClimbing = false;
           r2d.gravityScale = 4f;

       }
       if(isClimbing == true)
       {
            //inputVertical = Input.GetAxisRaw("Vertical");
            //r2d.velocity = new Vector2(moveDirection * horizontalJumpVelocity / 2, r2d.velocity.y);
            //r2d.gravityScale = 0;
            isGrounded = true;
       }
       
        // if(isGrounded)
        // {
        //     r2d.velocity = new Vector2(moveDirection * maxSpeed, r2d.velocity.y);
        //     horizontalJumpVelocity = maxSpeed;
        // }
        //Decrease X velo in midair
        if(isMoving)
        {
            horizontalJumpVelocity = maxSpeed;
        } else {
            horizontalJumpVelocity = horizontalJumpVelocity * midairVeloDecrease;
        }
        r2d.velocity = new Vector2(moveDirection * horizontalJumpVelocity, r2d.velocity.y);

        // // Simple debug
        // Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(0, colliderRadius, 0), isGrounded ? Color.green : Color.red);
        // Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(colliderRadius, 0, 0), isGrounded ? Color.green : Color.red);
    }
    
}