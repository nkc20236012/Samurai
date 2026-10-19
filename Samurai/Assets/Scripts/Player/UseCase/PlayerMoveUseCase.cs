using UnityEngine;

public class PlayerMoveUseCase
{
    private PlayerInputEntity _inputEntity;
    private PlayerStatusEntity _statusEntity;
    private Rigidbody _rigidbody;
    public PlayerMoveUseCase(PlayerInputEntity inputEntity,PlayerStatusEntity statusEntity,
        Rigidbody rigidbody)
    {
        _inputEntity = inputEntity;
        _statusEntity = statusEntity;
        _rigidbody = rigidbody;
    }

    public void Move()
    {
        Vector3 moveVelocity = _inputEntity.MoveInput * _statusEntity.MoveSpeed;
        _rigidbody.linearVelocity =
            new Vector3(moveVelocity.x, _rigidbody.linearVelocity.y, moveVelocity.z);
    }
}
