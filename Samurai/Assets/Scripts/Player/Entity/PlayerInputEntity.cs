using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputEntity
{
    public PlayerInputEntity(PlayerInput input)
    {
        input.Player.Move.performed += OnMove;
        input.Player.Move.canceled += OutMove;
        input.Player.Sprint.started += OnSprint;
        input.Player.Sprint.canceled += OnSprint;
        input.Player.Camera.performed += OnCameraMove;
    }

    public Vector3 MoveInput {  get; private set; }
    public bool IsSprint {  get; private set; }
    public Vector3 CameraMove {  get; private set; }

    private void OnMove(InputAction.CallbackContext context)
    {
        MoveInput = new Vector3(context.ReadValue<Vector2>().x,0,context.ReadValue<Vector2>().y);
    }
    private void OutMove(InputAction.CallbackContext context)
    {
        MoveInput = Vector3.zero;
    }
    private void OnSprint(InputAction.CallbackContext context)
    {
        IsSprint = context.ReadValueAsButton();
    }
    private void OnCameraMove(InputAction.CallbackContext context)
    {
        CameraMove = new Vector3(context.ReadValue<Vector2>().x, 0, context.ReadValue<Vector2>().y);
    }
}
