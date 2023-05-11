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

    //wallJumping
    public bool walled;
    public bool wallJumped;
    public float smoothness;
    public float jumpDelay;

    //drag
    public float wallDrag;
    public float groundDrag;

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
       //drag
      if(walled)
        {
            rb.drag = wallDrag;
        }
        else
        {
            rb.drag = groundDrag;
        }
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
        Invoke("WallJumpReset", jumpDelay);
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
            Vector3 wallPosition = contactPoint - contact.normal * 0.5f; // adjust the 0.5f offset as needed
            Vector3 wallVector = wallPosition - playerPosition;

            if (wallVector.z < 0)
            {
                Quaternion targetRotation = Quaternion.Euler(cam.transform.rotation.eulerAngles.x, cam.transform.rotation.eulerAngles.y, 10f);
                cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, targetRotation, smoothness * Time.deltaTime);
            }
            else if (wallVector.z > 0)
            {
                Quaternion targetRotation = Quaternion.Euler(cam.transform.rotation.eulerAngles.x, cam.transform.rotation.eulerAngles.y, -10f);
                cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, targetRotation, smoothness * Time.deltaTime);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Quaternion targetRotation = Quaternion.Euler(cam.transform.rotation.eulerAngles.x, cam.transform.rotation.eulerAngles.y, 0);
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


