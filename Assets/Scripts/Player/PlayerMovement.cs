using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour, IMovement
{
    [field: SerializeField] public float moveSpeed { get; set; } = 1;
    [field: SerializeField] public float rotationSpeed { get; set; } = 1;
    public Rigidbody rb { get; set; }
    [field: SerializeField] public FloatingJoystick joystick { get; set; }

    private Vector3 movement;

    public static PlayerMovement instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (PlayerLifeState.instance.GetLifeState())
        {
            if (joystick.Direction != Vector2.zero) 
            {
                PlayerAnimations.instance.WalkAnimation();
            }
            else
            {
                PlayerAnimations.instance.IdleAnimation();  
            }
        }
    }

    private void FixedUpdate()
    {
        if (PlayerLifeState.instance.GetLifeState())
        { 
            Vector3 movement = new Vector3(joystick.Horizontal * moveSpeed, 0f ,joystick.Vertical);
            Move(movement);
        }
    }

    public void Move(Vector3 direction)
    {
        rb.velocity = direction.normalized * moveSpeed;
        ConvertDirectionToYRotation(direction);
    }

    public void ConvertDirectionToYRotation(Vector3 dir)
    {
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            Vector3 direction = Vector3.RotateTowards(transform.forward, dir, rotationSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
