using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GusScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float rotationSpeed = 0.75f;
    // Start is called before the first frame update
    public string groundTag = "Ground";
    private bool StemLocked = true;
    private float timeJumpHeld = 0;
    public float maxJump = 10f;
    public float minJump = 5f;
    public float heldJumpMultiplier = 2f;
    
    public Camera mainCamera;
    private Color stationaryColor = Color.gray;
    private Color movingColor = Color.yellow;
    private float transitionSpeed = 2f;

    private float headBounceForce;

    private float startingHeadBounceForce;

    private int flipDirection = 0;
    private float cumulativeOneDirectionRoatation = 0;
    private float lastRotation = 0;
    public float consecutiveFlips = 0;

    void Start()
    {
        lastRotation = myRigidbody.transform.eulerAngles.z;
        headBounceForce = GameObject.Find("Head").GetComponent<HeadBounceScript>().bounceForce;
        startingHeadBounceForce = GameObject.Find("Head").GetComponent<HeadBounceScript>().startingBounceForce;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) {
            if (StemLocked) {
                timeJumpHeld += Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space)) {
            if (StemLocked) {
                myRigidbody.velocity = Vector2.up * Mathf.Max(Mathf.Min(timeJumpHeld * heldJumpMultiplier, maxJump), minJump);
                timeJumpHeld = 0;
            }
        }
        
        if (Input.GetKey(KeyCode.A)) {
            if (!StemLocked) {
                myRigidbody.rotation += rotationSpeed;
            }
                
        } else if (Input.GetKey(KeyCode.D)) {
            if (!StemLocked) {
                myRigidbody.rotation -= rotationSpeed;
            }
        }

        if (myRigidbody.velocity.magnitude > 0.1f) {
            mainCamera.backgroundColor = Color.Lerp(mainCamera.backgroundColor, movingColor, Time.deltaTime * transitionSpeed);
        } else {
            mainCamera.backgroundColor = Color.Lerp(mainCamera.backgroundColor, stationaryColor, Time.deltaTime * transitionSpeed);
        }

        DetectFlip();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag(groundTag)) {
            StemLocked = true;
            GameObject.Find("Head").GetComponent<HeadBounceScript>().bounceForce = startingHeadBounceForce;
            consecutiveFlips = 0;
        } 
    }

    private void OnTriggerExit2D(Collider2D collision) {
        StemLocked = false;
    }

    private void DetectFlip() {
        float currentRotation = myRigidbody.transform.eulerAngles.z;
        float rotationChange = Mathf.DeltaAngle(lastRotation, currentRotation);

        if (rotationChange > 0 && !(flipDirection == 1)) {
            flipDirection = 1;
            cumulativeOneDirectionRoatation = 0;
        } else if (rotationChange < 0 && !(flipDirection == -1)) {
            flipDirection = -1;
            cumulativeOneDirectionRoatation = 0;
        }


        if (Mathf.Abs(cumulativeOneDirectionRoatation) > 360) {
            Debug.Log("FLIP");
            Debug.Log("Starting force" + startingHeadBounceForce);
            if ((GameObject.Find("Head").GetComponent<HeadBounceScript>().bounceForce) < startingHeadBounceForce) {
                GameObject.Find("Head").GetComponent<HeadBounceScript>().bounceForce += 1;
            }
            cumulativeOneDirectionRoatation = 0;
            consecutiveFlips += 1;
        }
        
        cumulativeOneDirectionRoatation += rotationChange;
        lastRotation = currentRotation;
    }
}
