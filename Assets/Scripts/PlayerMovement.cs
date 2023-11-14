using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float mSpeed = 100f;
    float walkSpeed = 140f;
    float runSpeed = 200f;

    float jumpForce = 150f;

    public LayerMask ground;
    public Transform groundDetector;

    [SerializeField] Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveZ = Input.GetAxisRaw("Vertical");
        bool run = (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift));
        bool jump = (Input.GetKey(KeyCode.Space) && GroundCheck());

        if (run == true && moveZ > 0)
            mSpeed = runSpeed;
        else 
            mSpeed = walkSpeed;

        if (jump == true)
            rb.AddForce(Vector3.up * jumpForce);

            Vector3 direction = new Vector3(0, 0, moveZ);
        direction.Normalize();

        Vector3 velVector = transform.TransformDirection(direction) * mSpeed * Time.fixedDeltaTime;
        velVector.y = rb.velocity.y;
        rb.velocity = velVector;
    }

    bool GroundCheck()
    {
        return Physics.Raycast(groundDetector.position, Vector3.down, .1f, ground);
    }
}
