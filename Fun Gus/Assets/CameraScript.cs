using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject Player;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = new Vector3(Player.transform.position.x, Player.transform.position.y, -5);
        transform.position= playerPos;
    }
}
