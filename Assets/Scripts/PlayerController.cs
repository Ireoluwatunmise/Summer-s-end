using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float forwardInput;
    public float speed = 100.0f;
    public float range = 20;
    private Rigidbody playerRb;
    public GameObject focalPoint;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;



    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
       
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(focalPoint.transform.forward * forwardInput * speed * Time.deltaTime);
        
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * speed * Time.deltaTime);


        if (transform.position.x < -range)
        {
            transform.position = new Vector3(-range, transform.position.y, transform.position.z);
        }
        if (transform.position.x > range)
        {
            transform.position = new Vector3(range, transform.position.y, transform.position.z);
        }
        if (transform.position.z < -range)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -range);
        }
        if (transform.position.z > range)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, range);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
          isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }
}
