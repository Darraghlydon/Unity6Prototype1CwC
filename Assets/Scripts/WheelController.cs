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
    
    public InputAction BrakeAction;
    
    private float currentAcceleration = 0f;
    private float currentBrakingForce = 0f;
    private float currentTurnAngle = 0f; 
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MoveAction.Enable();
        BrakeAction.Enable();
    }

    void FixedUpdate()
    {
        HandleAcceleration();

        HandleBraking();

        HandleTurning();

        HandleWheelVisuals();
    }

    private void HandleAcceleration()
    {
        moveInput = MoveAction.ReadValue<Vector2>();
        currentAcceleration = acceleration*moveInput.y;
        
        frontRightWheel.motorTorque = currentAcceleration;
        frontLeftWheel.motorTorque = currentAcceleration;
    }
    
    
    private void HandleBraking()
    {
        if (BrakeAction.IsPressed())
        {
            currentBrakingForce = brakingForce;
        }
        else currentBrakingForce = 0f;
        
        frontRightWheel.brakeTorque = currentBrakingForce;
        frontLeftWheel.brakeTorque = currentBrakingForce;
        backRightWheel.brakeTorque = currentBrakingForce;
        backLeftWheel.motorTorque = currentBrakingForce;
    }

    private void HandleTurning()
    {
        currentTurnAngle = maxTurnAngle * moveInput.x;
        
        frontLeftWheel.steerAngle = currentTurnAngle;
        frontRightWheel.steerAngle = currentTurnAngle;
    }
    
    
    private void HandleWheelVisuals()
    {
        //Update Wheel Meshes
        UpdateWheel(frontLeftWheel, frontLeftWheelTransform);
        UpdateWheel(frontRightWheel, frontRightWheelTransform);
        UpdateWheel(backLeftWheel, backLeftWheelTransform);
        UpdateWheel(backRightWheel, backRightWheelTransform);
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
