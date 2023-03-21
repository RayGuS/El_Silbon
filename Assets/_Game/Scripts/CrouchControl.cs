using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CrouchControl : MonoBehaviour
{
    public InputActionProperty accion;
    public InputAction Crouch;
    public PlayerInput _playerInput;
    public ThirdPersonController _thirdPersonController;

    Animator anim;
    public float CrouchSpeed = 0.5f;
    protected bool isCrouching = false;
    
    protected CapsuleCollider capCollider;

    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        anim = GetComponent<Animator>();
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
        anim.SetBool("Crouch", _playerInput.actions["Crouch"].ReadValue<float>() > 0.5f);
        if (_playerInput.actions["Crouch"].ReadValue<float>() == 1f)
        {
            _thirdPersonController._speed = CrouchSpeed;
            capCollider.height = 0.5f;
            capCollider.center = new Vector3(capCollider.center.x, 0.25f, capCollider.center.z);
        }

        //Debug.DrawRay(transform.position, Vector3.up * 2f, Color.green);

        if (_playerInput.actions["Crouch"].ReadValue<float>() == 0f)
        {
            var cantStandup = Physics.Raycast(transform.position, Vector3.up, 2f);
            if (!cantStandup)
            {
                capCollider.height = 1f;
                capCollider.center = new Vector3(capCollider.center.x, 0.5f, capCollider.center.z);
            }
        }
    }
}