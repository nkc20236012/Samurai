using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerInput PlayerInputAction { get; set; }

    [SerializeField]
    private PlayerStatus _statusData;

    private Rigidbody _rigidbody;
    private PlayerInput _input => PlayerInputAction;
    private PlayerInputEntity _inputEntity;
    private PlayerMoveUseCase _moveUseCase;
    public void Start()
    {
        _rigidbody = GetComponentInChildren<Rigidbody>();
        PlayerStatusEntity statusEntity = new PlayerStatusEntity(_statusData);
        _inputEntity = new PlayerInputEntity(_input);
        _moveUseCase = new PlayerMoveUseCase(_inputEntity, statusEntity,_rigidbody);
    }

    public void Update()
    {
        if(_inputEntity.MoveInput.magnitude != 0)
        {
            _moveUseCase.Move();
        }
    }
}
