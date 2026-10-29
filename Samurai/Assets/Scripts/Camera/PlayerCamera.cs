using UnityEngine;
using UnityEngine.InputSystem;
using System;

//プレイヤーカメラ制御
public class PlayerCamera : MonoBehaviour
{
    //[Header("入力")]
    //[SerializeField]
    //private PlayerInput _playerInput;
    //[Header("ポジション")]
    //[SerializeField]
    //private Transform _playerPos;
    //[Header("パラメータ")]
    //[SerializeField]
    //private PlayerCameraParameter _cameraData;
    //[Header("ロックオンターゲット")]
    //[SerializeField]
    //private GameObject _lockOnCursor;

    //public Subject<bool> IsLockOn = new Subject<bool>();
    //public Subject<Vector3> LockOnTarget = new Subject<Vector3>();

    //private CameraStatusEntity _statusEntity;
    //private CameraMoveUseCase _moveUseCase;
    //private CameraSearchUseCase _searchUseCase;
    //private Camera _mainCamera;
    //private Input _input;
    //private Action _stateAction;
    //private Action _changeStateAction;
    //private Vector2 _playerLookVector;
    //private Vector2 _lockVector;
    //private Vector3 _targetPos;
    //private float _inputX;
    //private float _inputY;
    //private float _lockCoolTime = 1;
    //private bool _isTargrtCange = true;
    //private bool _isLockOn = false;
    //private bool _isMouseLook = false;

    //void Awake()
    //{
    //    //初期化
    //    Cursor.visible = false;
    //    Cursor.lockState = CursorLockMode.Locked;
    //    _mainCamera = Camera.main;
    //    _statusEntity = new CameraStatusEntity(_cameraData, _mainCamera, _playerPos);
    //    _moveUseCase = new CameraMoveUseCase(_statusEntity);
    //    _searchUseCase = new CameraSearchUseCase(_statusEntity);

    //    //入力
    //    _input = _playerInput.InputAction;
    //    _input.Player.Look.performed += OnLook;
    //    _input.Player.LockOn.started += OnLockOn;
    //    _lockOnCursor.SetActive(false);

    //    //初期ステート
    //    _stateAction = FreeUpdate;
    //}

    //private void LateUpdate()
    //{
    //    //入力
    //    _playerLookVector = _input.Player.Look.ReadValue<Vector2>();
    //    //マウス、キーボードの場合
    //    if (_isMouseLook)
    //    {
    //        _inputX += _playerLookVector.x * _cameraData.mouseRotSpeed;
    //        _inputY += _playerLookVector.y * _cameraData.mouseRotSpeed;
    //    }
    //    //コントローラの場合
    //    else
    //    {
    //        _inputX += _playerLookVector.x * _cameraData.controllerRotSpeed;
    //        _inputY += _playerLookVector.y * _cameraData.controllerRotSpeed / 2;
    //    }

    //    //入力制限
    //    _inputY = Mathf.Clamp(_inputY, _cameraData.minRotCramp, _cameraData.maxRotCramp);

    //}
    //private void Update()
    //{
    //    //ステート実行
    //    _stateAction?.Invoke();
    //}
    ///// <summary>
    ///// フリーカメラ(ロックオンしていないか)
    ///// </summary>
    //private void FreeUpdate()
    //{
    //    // カメラの位置を計算
    //    Vector3 offset = new Vector3(0, 0, -_cameraData.distance);
    //    Quaternion rotation = Quaternion.Euler(-_inputY, _inputX, 0);
    //    Vector3 desiredPosition = _playerPos.position + Vector3.up
    //        * _cameraData.height + rotation * offset;

    //    ////カメラ～プレイヤー間の障害物チェック
    //    _moveUseCase.WallHitCamera(desiredPosition);
    //    // プレイヤーを見るベクトルを計算
    //    _moveUseCase.MainCameraTargetLookAt(_playerPos.position);
    //}

    ///// <summary>
    ///// ロックオンカメラ(ロックオン中)
    ///// </summary>
    //private void LockOnUpdate()
    //{
    //    // カメラの位置を計算
    //    if (!TargetCheck(_statusEntity.TargetObj)) return;
    //    Vector3 pos = _playerPos.position - _statusEntity.TargetHit.transform.position;
    //    pos.y = 0;
    //    pos.Normalize();
    //    pos *= _cameraData.lockDistance;
    //    pos.y = _cameraData.lockHeight;
    //    _mainCamera.transform.position = _playerPos.position + pos;
    //    //カメラ～プレイヤー間の障害物チェック
    //    _moveUseCase.WallHitCamera(_playerPos.position + pos);
    //    // ターゲットを見るベクトルを計算
    //    _moveUseCase.MainCameraTargetLookAt(_statusEntity.TargetHit.transform.position);
    //    //カメラの回転角保存
    //    Vector3 euler = _mainCamera.transform.rotation.eulerAngles;
    //    _inputX = euler.y;
    //    _inputY = euler.x - _cameraData.inputResetY;

    //    //Playerスクリプトへ受け渡し
    //    LockOnTarget.OnNext(_statusEntity.TargetHit.transform.position);
    //    //ロックオンポインター
    //    _lockOnCursor.transform.position = _mainCamera.WorldToScreenPoint(_statusEntity.TargetHit.transform.position);

    //    //ターゲット変更可能か
    //    if (!_isTargrtCange)
    //    {
    //        _lockCoolTime -= Time.deltaTime;
    //    }
    //    //ターゲット変更のクールタイム
    //    if (_lockCoolTime < 0)
    //    {
    //        _lockCoolTime = 1;
    //        _isTargrtCange = true;
    //    }
    //}

    ///// <summary>
    ///// 切り替え補間Update
    ///// </summary>
    //private void ModeChangeUpdate()
    //{
    //    Vector3 direction = (_targetPos + Vector3.up * _cameraData.height - _mainCamera.transform.position).normalized;
    //    Vector3 up = Vector3.up;
    //    Vector3 right = Vector3.Cross(up, direction).normalized;
    //    up = Vector3.Cross(direction, right);
    //    _mainCamera.transform.rotation = Quaternion.Slerp
    //        (_mainCamera.transform.rotation, Quaternion.LookRotation(direction, up), _cameraData.modeChangeTime);
    //    Quaternion targetRot = Quaternion.LookRotation(direction, up);
    //    if (Quaternion.Angle(_mainCamera.transform.rotation, targetRot) < _cameraData.rotationTolerance)
    //    {
    //        if (_changeStateAction == FreeUpdate)
    //        {
    //            _stateAction = FreeUpdate;
    //        }
    //        else
    //        {
    //            _stateAction = LockOnUpdate;
    //        }
    //    }
    //}

    //// ==================================================
    ////  State切り替え
    //// ==================================================
    //private void SetFree()
    //{
    //    _isLockOn = false;
    //    IsLockOn.OnNext(_isLockOn);
    //    _targetPos = _playerPos.transform.position;
    //    _changeStateAction = FreeUpdate;
    //    _stateAction = ModeChangeUpdate;
    //}
    //private void SetLockOn()
    //{
    //    _isLockOn = true;
    //    IsLockOn.OnNext(_isLockOn);
    //    _targetPos = _statusEntity.TargetHit.transform.position;
    //    _changeStateAction = LockOnUpdate;
    //    _stateAction = ModeChangeUpdate;
    //}
    //// ==================================================
    ////  入力
    //// ==================================================
    ///// <summary>
    ///// フリーカメラ入力(マウス、コントローラの入力取得)
    ///// </summary>
    ///// <param name="context"></param>
    //private void OnLook(InputAction.CallbackContext context)
    //{
    //    if (!_isLockOn)
    //    {
    //        //接続されている入力デバイス識別
    //        if (context.control.device is Mouse)
    //        {
    //            _isMouseLook = true;
    //        }
    //        else
    //        {
    //            _isMouseLook = false;
    //        }
    //    }
    //    else
    //    {
    //        //ロックオンターゲット変更
    //        _lockVector = context.ReadValue<Vector2>();
    //        float changePower = _isMouseLook ? _cameraData.mouseLockChangePower : _cameraData.controllerLockChangePower;
    //        //入力が設定値を超えたらターゲット変更
    //        if (_lockVector.magnitude > changePower && _isTargrtCange)
    //        {
    //            TargetChange();
    //        }
    //    }
    //}
    //private void OnLockOn(InputAction.CallbackContext context)
    //{
    //    ChangeCameraMode();
    //}

    //// ==================================================
    ////  カメラ切り替え時の処理
    //// ==================================================
    //private void ChangeCameraMode()
    //{
    //    //ロックオン起動時処理
    //    if (!_isLockOn)
    //    {
    //        //敵サーチ
    //        _searchUseCase.SearchEnemy();
    //        //一体のみなら即起動
    //        if (_statusEntity.TargetList.Count == 1)
    //        {
    //            _statusEntity.SetTargetHit(_statusEntity.TargetList[0]);
    //            _statusEntity.SetTargetObj();
    //            _lockOnCursor.SetActive(true);
    //            SetLockOn();
    //        }
    //        //二体以上ならソート
    //        else if (_statusEntity.TargetList.Count >= 2)
    //        {
    //            _statusEntity.SetTargetHit(_searchUseCase.GetNearestEnemy());
    //            _statusEntity.SetTargetObj();
    //            _lockOnCursor.SetActive(true);
    //            SetLockOn();
    //        }
    //    }
    //    //ロックオン解除
    //    else
    //    {
    //        SetFree();
    //        _lockOnCursor.SetActive(false);
    //    }

    //}
    //private bool TargetCheck(GameObject target)
    //{
    //    if (target.gameObject.activeSelf == true) { return true; }
    //    else
    //    {
    //        SetFree();
    //        _lockOnCursor.SetActive(false);
    //        return false;
    //    }
    //}

    //private void TargetChange()
    //{
    //    _isTargrtCange = false;
    //    _searchUseCase.SearchEnemy();
    //    _statusEntity.SetTargetHit(_searchUseCase.GetEnemys(_lockVector.x));
    //}
    //private void OnDisable()
    //{
    //    Cursor.visible = true;
    //    Cursor.lockState = CursorLockMode.None;
    //    _input.Player.Look.performed -= OnLook;
    //    _input.Player.LockOn.started -= OnLockOn;
    //    IsLockOn.OnCompleted();
    //    LockOnTarget.OnCompleted();
    //}
}
