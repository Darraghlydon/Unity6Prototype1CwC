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

    
    [SerializeField]
    Transform frontLeftWheelTransform;
    [SerializeField]
    Transform frontRightWheelTransform;
    [SerializeField]
    Transform backLeftWheelTransform;
    [SerializeField]
    Transform backRightWheelTransform;
    

    public float acceleration = 500f;

    public float brakingForce = 300f;


    public float maxTurnAngle = 15f;
    
    public InputAction MoveAction;
    private Vector2 moveInput;
    
    private float currentAcceleration = 0f;
    private float currentBrakingForce = 0f;
    private float currentTurnAngle = 0f; 

    void FixedUpdate()
    {
        moveInput = MoveAction.ReadValue<Vector2>();
        currentAcceleration = acceleration*moveInput.y;
        
        
     
        
        

        
        frontRightWheel.motorTorque = currentAcceleration;
        frontLeftWheel.motorTorque = currentAcceleration;
        
        
        if (Input.GetKey(KeyCode.Space))
        {
            currentBrakingForce = brakingForce;
        }
        else currentBrakingForce = 0f;
        
        frontRightWheel.brakeTorque = currentBrakingForce;
        frontLeftWheel.brakeTorque = currentBrakingForce;
        backRightWheel.brakeTorque = currentBrakingForce;
        backLeftWheel.motorTorque = currentBrakingForce;
        
        
        
        currentTurnAngle = maxTurnAngle * moveInput.x;
        
        frontLeftWheel.steerAngle = currentTurnAngle;
        frontRightWheel.steerAngle = currentTurnAngle;
        
        //Update Wheel Meshes
        UpdateWheel(frontLeftWheel, frontLeftWheelTransform);
        UpdateWheel(frontRightWheel, frontRightWheelTransform);
        UpdateWheel(backLeftWheel, backLeftWheelTransform);
        UpdateWheel(backRightWheel, backRightWheelTransform);
        
        }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MoveAction.Enable();
    }


    void UpdateWheel(WheelCollider wheelCol, Transform wheelTransform)
    {
        Vector3 position;
        Quaternion rotation;
        wheelCol.GetWorldPose(out position, out rotation);
        wheelTransform.position = position;
        wheelTransform.rotation = rotation;
    }

  
}
