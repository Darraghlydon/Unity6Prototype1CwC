using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 35;
    [SerializeField]
    private float turnSpeed = 45.0f;


    public InputAction MoveAction; 
    private Vector2 moveInput;
    
    Rigidbody myRigidbody;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MoveAction.Enable();
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = MoveAction.ReadValue<Vector2>();
        
        //Moves the vehicle forward based on vertical input
      //  transform.Translate(Vector3.forward * (Time.deltaTime * speed*moveInput.y));
        //Rotates the vehicle based on horizontal input
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * moveInput.x);
        
    }


    void FixedUpdate()
    {
        moveInput = MoveAction.ReadValue<Vector2>();
        
        Vector3 forwardVelocity = transform.forward * (moveInput.y * speed);
        myRigidbody.linearVelocity = new Vector3(forwardVelocity.x, myRigidbody.linearVelocity.y, forwardVelocity.z);
        
        //myRigidbody.AddTorque(transform.up * (turnSpeed * moveInput.x * Time.fixedDeltaTime),ForceMode.Acceleration);

    }
}
