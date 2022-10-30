using UnityEngine;

public class OldPlayerController : BasePlayerController
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
        var direction = Input.GetAxis("Horizontal") * _sideSpeed * Time.fixedDeltaTime;

        if (direction == 0f) return;
        _rigidBody.position += direction * transform.right;
    }
}
