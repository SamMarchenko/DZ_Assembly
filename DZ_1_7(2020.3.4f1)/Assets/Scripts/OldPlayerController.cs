using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldPlayerController : BasePlayerController
{
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
        var direction = Input.GetAxis("Horizontal") * _sideSpeed * Time.fixedDeltaTime;

        if (direction == 0f) return;
        _rigidBody.position += direction * transform.right;
    }
}
