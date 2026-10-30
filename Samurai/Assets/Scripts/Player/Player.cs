using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerInput PlayerInputAction { get; set; }
    public PlayerCameraEntity CameraEntity { get; set; }

    [SerializeField]
    private PlayerStatus _statusData;
    [SerializeField]
    private PlayerStateData _stateData;
    [SerializeField]
    private CapsuleCollider _playerHit;
    [SerializeField]
    private BoxCollider _playerAttack;
    [SerializeField]
    private Transform _groundTransform;

    private PlayerStateMachine _stateMachine;
    private PlayerInput _input => PlayerInputAction;
    private PlayerCameraEntity _cameraEntity => CameraEntity;
    public void Start()
    {
        Rigidbody rigidbody = GetComponentInChildren<Rigidbody>();

        //Entity
        PlayerStatusEntity statusEntity = new PlayerStatusEntity(_statusData);
        PlayerInputEntity inputEntity = new PlayerInputEntity(_input);
        PlayerColliderEntity colliderEntity = new PlayerColliderEntity(_playerHit,_playerAttack);
        PlayerAnimationEntity animationEntity = new PlayerAnimationEntity(GetComponentInChildren<Animator>());
        PlayerGroundEntity groundEntity = new PlayerGroundEntity(_groundTransform, _statusData.Distance,
            _statusData.GroundMask);

        //UseCase
        PlayerMoveUseCase moveUseCase = new PlayerMoveUseCase(inputEntity, statusEntity,_cameraEntity,
            rigidbody,this.transform);
        PlayerCameraUseCase cameraUseCase = new PlayerCameraUseCase(CameraEntity);
        PlayerColliderUseCase colliderUseCase = new PlayerColliderUseCase(colliderEntity);
        PlayerAnimationUseCase animationUse = new PlayerAnimationUseCase(animationEntity);
        PlayerGroundUseCase groundUseCase = new PlayerGroundUseCase(groundEntity);

        //Context
        PlayerBaseContext baseContext =
            new PlayerBaseContext(statusEntity, inputEntity,_cameraEntity,moveUseCase,
            cameraUseCase,colliderUseCase,animationUse,groundUseCase);

        _stateMachine = new PlayerStateMachine(baseContext,_stateData);
        _stateMachine.Initialize(StateType.Idle);
    }

    public void Update()
    {
        _stateMachine.OnUpdate();
    }

    public void FixedUpdate()
    {
        _stateMachine.OnFixedUpdate();
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.down * _statusData.Distance);
    }

}
