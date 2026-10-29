using UnityEngine;

public class PlayerMoveUseCase
{
    private PlayerInputEntity _inputEntity;
    private PlayerStatusEntity _statusEntity;
    private PlayerCameraEntity _cameraEntity;
    private Rigidbody _rigidbody;
    private Transform _playerTransform;
    public PlayerMoveUseCase(PlayerInputEntity inputEntity,PlayerStatusEntity statusEntity,
        PlayerCameraEntity cameraEntity,Rigidbody rigidbody,Transform transform)
    {
        _inputEntity = inputEntity;
        _statusEntity = statusEntity;
        _cameraEntity = cameraEntity;
        _rigidbody = rigidbody;
        _playerTransform = transform;
    }

    public void Stop()
    {
        _rigidbody.linearVelocity = new Vector3(0,_rigidbody.linearVelocity.y,0);
    }

    //ì¸óÕï˚å¸Ç…à⁄ìÆéwé¶
    public void Walk()
    {
        Quaternion cameraAngle =
            Quaternion.AngleAxis(_cameraEntity.CameraTrancform.eulerAngles.y, Vector3.up);
        Vector3 moveVelocity = cameraAngle * (_inputEntity.MoveInput * _statusEntity.Speed);
        _playerTransform.rotation =
            Quaternion.Slerp(_playerTransform.rotation, Quaternion.LookRotation(
            _inputEntity.MoveInput) * cameraAngle, 0.2f);
        _rigidbody.linearVelocity =
            new Vector3(moveVelocity.x, _rigidbody.linearVelocity.y, moveVelocity.z);

    }

    //ÉJÉÅÉâï˚å¸Ç…à⁄ìÆéwé¶
    public void Boost()
    {
        Vector3 cameraAngle = _cameraEntity.CameraTrancform.forward;
        Vector3 moveVelocity = cameraAngle * _statusEntity.Speed;
        _playerTransform.rotation =
            Quaternion.Slerp(_playerTransform.rotation, Quaternion.LookRotation(cameraAngle), 0.2f);
        _rigidbody.linearVelocity =
            new Vector3(moveVelocity.x, moveVelocity.y, moveVelocity.z);
    }

    public void BoostStop()
    {
        Quaternion cameraAngle =
            Quaternion.AngleAxis(_cameraEntity.CameraTrancform.eulerAngles.y, Vector3.up);
        _playerTransform.rotation = cameraAngle;
        _rigidbody.linearVelocity =
            new Vector3(_rigidbody.linearVelocity.x/2, _rigidbody.linearVelocity.y, _rigidbody.linearVelocity.z/2);
    }

    public void Attack()
    {
        Vector3 cameraAngle = _cameraEntity.CameraTrancform.forward;
        _playerTransform.rotation =
            Quaternion.Slerp(_playerTransform.rotation, Quaternion.LookRotation(cameraAngle), 0.2f);
        _rigidbody.linearVelocity =
            new Vector3(_rigidbody.linearVelocity.x / 2, _rigidbody.linearVelocity.y, _rigidbody.linearVelocity.z / 2);
    }
    public void Charge()
    {
        Vector3 cameraAngle = _cameraEntity.CameraTrancform.forward;
        _playerTransform.rotation =
            Quaternion.Slerp(_playerTransform.rotation, Quaternion.LookRotation(cameraAngle), 0.2f);
    }
}
