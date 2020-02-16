using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
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

   


    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();

        

        

        moveSpeedStore = moveSpeed;

        speedMilestoneCount = speedIncreaseMilestone;

    }

    // Update is called once per frame
    void Update()
    {
        
        //acceleration per time and increasing milestone range
        if (transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;

            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;

            moveSpeed = moveSpeed * speedMultiplier;
        }

        myRigidBody.velocity = new Vector3(moveSpeed, myRigidBody.velocity.y);


     
    }


    
}
