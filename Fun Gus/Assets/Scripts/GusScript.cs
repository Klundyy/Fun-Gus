//Video Used for hold jump 
//https://www.youtube.com/watch?v=j111eKN8sJw
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GusScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float jumpForce;
    public float rotationSpeed;
    private float moveInput;


    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }



    private void FixedUpdate()
    { 
      }


    // Update is called once per frame
    void Update()
    {
        //Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);


        // Freeze Z rotation when grounded, unfreeze when in the air
        if (isGrounded)
        {
            myRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            myRigidbody.constraints = RigidbodyConstraints2D.None;
        }

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            myRigidbody.velocity = Vector2.up * jumpForce;
        }


        if (Input.GetKey(KeyCode.Space) && isJumping == true) 
        {
            if (jumpTimeCounter > 0)
            {
                myRigidbody.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }


        // Rotate player while in the air
        if (!isGrounded)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
            }
        }
    }
}
