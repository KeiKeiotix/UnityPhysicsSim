using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 10;
    public float jumpHeight = 2;
    public GameObject camera;

    public Vector3 hitDirection;
    public float slideTolerence = 0.1f;

    Vector3 velocity;
    CharacterController cc;
    Vector2 moveInput = new Vector2();
    bool jumpInput;


    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        jumpInput = Input.GetButton("Jump");
    }

    void FixedUpdate()
    {
        Vector3 delta;

        //move same direction as camera
        Vector3 camForward = camera.transform.forward;
        camForward.y = 0;
        camForward.Normalize();

        delta = (moveInput.x * camera.transform.right + moveInput.y * camForward).normalized * speed;

      


        // check for jumping
        if (jumpInput && cc.isGrounded)
        {
            velocity.y = Mathf.Sqrt(-2 * jumpHeight * Physics.gravity.y);
        }

        if (cc.isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }

        // apply gravity
        velocity += Physics.gravity * Time.fixedDeltaTime;

        if (!cc.isGrounded)
        {
            hitDirection = Vector3.zero;
        }

        if (moveInput.x == 0 && moveInput.y == 0 /*&& hitDirection.x > slideTolerence || hitDirection.y > slideTolerence */)
        {
            hitDirection.y = 0;

            Vector3 horizontalHitDirection = hitDirection;
            horizontalHitDirection.y = 0;
            float displacement = horizontalHitDirection.magnitude;
            
            if (displacement > 0)
            {
                velocity -= 0.2f * horizontalHitDirection / displacement;
            }
        }




        cc.Move((velocity + delta) * Time.deltaTime); ;
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        hitDirection = hit.point - transform.position;
    }

}
