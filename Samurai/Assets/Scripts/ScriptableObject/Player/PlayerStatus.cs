using UnityEngine;

[CreateAssetMenu(menuName = "Status")]
public class PlayerStatus : ScriptableObject
{
    public float Health;
    public float MoveSpeed;
    public float SprintSpeed;

    [Header("地面チェック")]
    public float Distance;
    public LayerMask GroundMask;
}
