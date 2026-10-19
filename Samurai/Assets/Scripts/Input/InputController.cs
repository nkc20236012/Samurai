using UnityEngine.InputSystem;

public class InputController
{
    public PlayerInput PlayerInputAction {  get; private set; } 
    public InputController()
    {
        PlayerInputAction = new PlayerInput();
        PlayerInputAction.Enable();
    }
}
