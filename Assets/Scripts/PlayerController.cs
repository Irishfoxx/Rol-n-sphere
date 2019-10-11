using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private float moveSpeedStore;
    public float speedMultiplier;

    public float speedIncreaseMilestone;
    public float speedIncreaseMilestoneStore;


    private float speedMilestoneCount;
    private float speedMilestoneCountStore;

    public float jumpForce;

    public float jumpTime;
    private float jumpTimeCounter;
    
    private Rigidbody2D myRigidBody;

    public bool onGround;
    public LayerMask whatIsGround;

    private Collider2D myCollider;

    public GameManager theGameManager;


    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<Collider2D>();

        jumpTimeCounter = jumpTime;

        moveSpeedStore = moveSpeed;

        speedMilestoneCount = speedIncreaseMilestone;
        
    }

    // Update is called once per frame
    void Update()
    {
        onGround = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        //acceleration per time and increasing milestone range
        if(transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;

            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;

            moveSpeed = moveSpeed * speedMultiplier;
        }
        
        myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);

        

        
        // TOUCH SETTINGS
        

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {

            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);

        }

        // KEYBOARD SETTINGS

        // let player jump

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (onGround)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
            }
        }

        // let player jump higher

        if (Input.GetKey(KeyCode.Space))
        {

            if (jumpTimeCounter > 0)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }

        }

        if (Input.GetKeyUp (KeyCode.Space))
        {
            jumpTimeCounter = 0;
        }

        if (onGround)
        {
            jumpTimeCounter = jumpTime;
        }
    }


    //DEATH TRIGGER
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "killbox")
        {



            theGameManager.RestartGame();
            moveSpeed = moveSpeedStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedIncreaseMilestone = speedIncreaseMilestoneStore;
            
        }
    }
}
