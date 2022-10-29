using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.PlayerConnection;

public class NewPlayerController : BasePlayerController
{
    private PlayerControls _playerControls;
    
    private void FixedUpdate()
    {
        var direction = _playerControls.Player.MoveSide.ReadValue<float>() * _sideSpeed * Time.fixedDeltaTime;

        if (direction == 0f) return;
        _rigidBody.position += direction * transform.right;
    }

    #region New Input System init

    protected override void Start()
    {
        base.Start();
        _playerControls.Player.Jump.performed += _ => Jump();
    }

    private void Awake()
    {
        _playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }

    private void OnDestroy()
    {
        _playerControls?.Dispose();
    }

    #endregion
   
}
