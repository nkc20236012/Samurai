using UnityEngine;
[CreateAssetMenu(menuName = "StateData")]
public class PlayerStateData : ScriptableObject
{
    [Header("チャージState")]
    public float ChargeStateEnd;
    [Header("ブースト")]
    public float AttackBlockTime;
    [Header("アタックState")]
    public float AttackTime;
    public float AttackTimeEnd;
    public float AttackStateEnd;
}
