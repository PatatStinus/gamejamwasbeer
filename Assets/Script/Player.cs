using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float sprintSpeed = 10f;
    public float normalSpeed = 5f;
    private float speed = 5f;
    public float jumpForce = 5f;
    public float wallJumpForce = 10f;
    public float lookSensitivity = 3f;
    public Camera cam;
    public bool grounded;
    public bool walled;
    public bool wallJumped;


    private Rigidbody rb;
    private float verticalLookRotation;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
      
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");
        // Jumping
        if (Input.GetKeyDown(KeyCode.Space)&& grounded && !walled)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.Space)&& walled && !grounded && !wallJumped)
        {
            WallJump();
        }

        //Sprinten
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
        }
        else
        {
            speed = normalSpeed;
        }

        //CameraControls
        float yRot = Input.GetAxisRaw("Mouse X") * lookSensitivity;
        transform.Rotate(0f, yRot, 0f);

        verticalLookRotation += Input.GetAxisRaw("Mouse Y") * lookSensitivity;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -60f, 60f);
        if (!walled)
        {
            cam.transform.localEulerAngles = new Vector3(-verticalLookRotation, 0f, 0f);
        }
        
    }
    //WallJumps
    private void WallJump()
    {
        
        rb.AddForce(Vector3.up * wallJumpForce, ForceMode.Impulse);
        wallJumped = true;
        Invoke("WallJumpReset", 2f);
    }
    //WallJump Timer
    private void WallJumpReset()
    {
        wallJumped = false;
    }
        private void FixedUpdate()
    {
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xMov;
        Vector3 moveVertical = transform.forward * zMov;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

        rb.AddForce(velocity * rb.mass, ForceMode.Impulse);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            grounded = true;
        }
        if (other.CompareTag("Wall"))
        {
            walled = true;

        }
    }
    void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Vector3 contactPoint = contact.point;
            Vector3 playerPosition = transform.position; 
            Vector3 contactVector = contactPoint - playerPosition;

           
            if (contactVector.x < 0)
            {
                cam.transform.rotation = Quaternion.Euler(0, 180, 20);
            }
            else if (contactVector.x > 0)
            {
                cam.transform.rotation = Quaternion.Euler(0, 180, -20);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("Ground"))
        {
            grounded = false;
        }
        if (other.CompareTag("Wall"))
        {
            walled = false;
        }
        
    }
}


