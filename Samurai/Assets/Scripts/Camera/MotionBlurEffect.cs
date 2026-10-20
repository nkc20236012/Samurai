using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MotionBlurEffect : MonoBehaviour
{
    [SerializeField] private Material _material;

    [Header("Motion Blur Settings")]
    [SerializeField, Range(0f, 1f)]
    private float _speedCoeff = 0f;

    [SerializeField, Range(0f, 0.2f)]
    private float _blurSize = 0.05f;

    [SerializeField, Range(0.1f, 5f)]
    private float _edgeCoeff = 1f;

    [SerializeField]
    private Vector2 _blurCenterPoint = new Vector2(0.5f, 0.5f);

    public void SetSpeedRatio(float ratio)
    {
        _speedCoeff = Mathf.Clamp01(ratio);
    }

    private void OnRenderImage(RenderTexture source,
        RenderTexture destination)
    {
        if (_material == null)
        {
            Graphics.Blit(source, destination);
            return;
        }

        _material.SetFloat("_SpeedCoeff", _speedCoeff);
        _material.SetFloat("_BlurSize", _blurSize);
        _material.SetFloat("_EdgeCoeff", _edgeCoeff);
        _material.SetVector("_BlurCenterPoint", _blurCenterPoint);

        Graphics.Blit(source, destination, _material);
    }
}