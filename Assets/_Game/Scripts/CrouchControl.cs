using JetBrains.Annotations;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class CrouchControl : MonoBehaviour
{
    public InputActionProperty accion;
    public InputAction Crouch;
    public PlayerInput _playerInput;
    public ThirdPersonController _thirdPersonController;

    private float moveSpeed;
    public float CrouchSpeed = 0.5f;
    private float sprintSpeed;

    public Animator anim;
    
    protected bool isCrouching = false;
    
    protected CapsuleCollider capCollider;

    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        moveSpeed = _thirdPersonController.MoveSpeed;
        sprintSpeed = _thirdPersonController.SprintSpeed;
        Crouch.Enable();
        capCollider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Crouching();
    }

    private void Crouching()
    {
        bool crouching = _playerInput.actions["Crouch"].ReadValue<float>() > 0.5f;
        anim.SetBool("Crouch",crouching);
        if (crouching)
        {
            _thirdPersonController.MoveSpeed = CrouchSpeed;
            _thirdPersonController.SprintSpeed = moveSpeed;
            capCollider.height = 0.5f;
            capCollider.center = new Vector3(capCollider.center.x, 0.25f, capCollider.center.z);
        }
        else
        {
            _thirdPersonController.MoveSpeed = moveSpeed;
            _thirdPersonController.SprintSpeed = sprintSpeed;
            var cantStandup = Physics.Raycast(transform.position, Vector3.up, 2f);
            if (!cantStandup)
            {
                capCollider.height = 1f;
                capCollider.center = new Vector3(capCollider.center.x, 0.5f, capCollider.center.z);
            }
        }
    }
}