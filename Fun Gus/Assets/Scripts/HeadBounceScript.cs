using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBounceScript : MonoBehaviour
{
    public Rigidbody2D stemRigidbody;
    public string groundTag = "Ground";
    public float startingBounceForce = 50f;
    public float bounceForce;
    // Start is called before the first frame update
    void Start()
    {
        bounceForce = startingBounceForce;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag(groundTag)) {
            //stemRigidbody.velocity = Vector2.up * bounceForce;
            float angle = stemRigidbody.transform.eulerAngles.z;
            angle = ((360)+(angle-90)) % 360;
            stemRigidbody.velocity = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)) * bounceForce;
            GameObject.Find("GusBody").GetComponent<GusScript>().consecutiveFlips = 0;
            if (bounceForce > startingBounceForce/2 && (GameObject.Find("GusBody").GetComponent<GusScript>().consecutiveFlips < 1)) {
                bounceForce--;
            }
            Debug.Log(bounceForce);
        } 
    }
}


