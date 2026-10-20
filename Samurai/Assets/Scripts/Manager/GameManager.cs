using Unity.Cinemachine;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerPrefab;
    [SerializeField]
    private GameObject _cameraPrefab;
    void Awake()
    {
        //生成
        InputController inputController = new InputController();
        GameObject camera = Instantiate(_cameraPrefab);
        GameObject playerObject = Instantiate(_playerPrefab);

        //変数、インスタンスの受け渡し
        var player = playerObject.GetComponent<Player>();
        player.PlayerInputAction = inputController.PlayerInputAction;
        CinemachineCamera cinemachine = camera.GetComponent<CinemachineCamera>();
        PlayerCameraEntity cameraEntity = new PlayerCameraEntity(Camera.main.transform, cinemachine);
        player.CameraEntity = cameraEntity;

        //カメラ初期設定
        Transform playerTramsform = playerObject.GetComponentInChildren<Transform>();
        cinemachine.Follow = playerTramsform.transform;
        cinemachine.LookAt = playerTramsform.transform;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        
    }
}
