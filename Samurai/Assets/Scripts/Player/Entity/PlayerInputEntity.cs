using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputEntity
{
    public PlayerInputEntity(PlayerInput input)
    {
        input.Player.Move.performed += OnMove;
        input.Player.Move.canceled += OnMove;
        input.Player.Camera.performed += OnCameraMove;
    }

    public Vector3 MoveInput {  get; private set; }
    public Vector3 CameraMove {  get; private set; }

    private void OnMove(InputAction.CallbackContext context)
    {
        MoveInput = new Vector3(context.ReadValue<Vector2>().x,0,context.ReadValue<Vector2>().y);
    }
    private void OnCameraMove(InputAction.CallbackContext context)
    {
        CameraMove = new Vector3(context.ReadValue<Vector2>().x, 0, context.ReadValue<Vector2>().y);
    }
}
