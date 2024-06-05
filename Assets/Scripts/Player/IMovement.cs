using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovement
{
    public float moveSpeed { get; set; }
    public float rotationSpeed { get; set; }
    Rigidbody rb { get; set; }
    FloatingJoystick joystick { get; set; }


    void Move(Vector3 direction);
}
