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

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (StemLocked) {
                myRigidbody.velocity = Vector2.up * 10;
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
