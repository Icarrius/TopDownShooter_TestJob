using System;
using UnityEngine;

[Serializable]
public struct MovementComponent
{
    public CharacterController characterController;
    public Transform mainTransform;
    public Vector3 velocity;
    public float gravity;
    public float movementSpeed;
}