using UnityEngine;
using UnityEngine.InputSystem;

public class WheelController : MonoBehaviour
{
    [SerializeField]
    WheelCollider frontLeftWheel;
    [SerializeField]
    WheelCollider frontRightWheel;
    [SerializeField]
    WheelCollider backLeftWheel;
    [SerializeField]
    WheelCollider backRightWheel;


    public float acceleration = 500f;

    public float brakingForce = 300f;
    
    public InputAction MoveAction;
    private Vector2 moveInput;
    
    private float currentAcceleration = 0f;
    private float currentBrakingForce = 0f;

    void FixedUpdate()
    {
        moveInput = MoveAction.ReadValue<Vector2>();
        currentAcceleration = acceleration*moveInput.y;
        
        
        if (Input.GetKey(KeyCode.Space))
        {
            currentBrakingForce = brakingForce;
        }
        else currentBrakingForce = 0f;
        
        

        
        frontRightWheel.motorTorque = currentAcceleration;
        frontLeftWheel.motorTorque = currentAcceleration;
        
        
        frontRightWheel.brakeTorque = currentBrakingForce;
        frontLeftWheel.brakeTorque = currentBrakingForce;
        backRightWheel.motorTorque = currentAcceleration;
        backLeftWheel.motorTorque = currentAcceleration;
        }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MoveAction.Enable();
    }

  
}
