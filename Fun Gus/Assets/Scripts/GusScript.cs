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
    public float heldJumpMultiplier = 2f;
    
    public Camera mainCamera;
    private Color stationaryColor = Color.gray;
    private Color movingColor = Color.yellow;
    private float transitionSpeed = 2f;

    void Start()
    {

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
                myRigidbody.velocity = Vector2.up * Mathf.Min(timeJumpHeld * heldJumpMultiplier, maxJump);
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

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag(groundTag)) {
            StemLocked = true;
        } 
    }

    private void OnTriggerExit2D(Collider2D collision) {
        StemLocked = false;
    }
}
