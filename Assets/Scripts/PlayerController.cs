using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float speed = 20;
    private float turnSpeed = 45.0f;


    public InputAction MoveAction; 
    private Vector2 moveInput;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MoveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = MoveAction.ReadValue<Vector2>();
        
        //Moves the vehicle forward based on vertical input
        transform.Translate(Vector3.forward * (Time.deltaTime * speed*moveInput.y));
        //Rotates the vehicle based on horizontal input
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * moveInput.x);
        
    }
}
