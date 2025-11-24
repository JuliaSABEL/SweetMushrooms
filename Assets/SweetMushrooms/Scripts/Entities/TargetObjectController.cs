using UnityEngine;


public class TargetObjectController : MonoBehaviour
{
    public ICarrier CurrentOwner { get; private set; }
    
    [SerializeField] private TargetObjectSettings _targetObjectSettings;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Collider2D _collider;

    private float _cooldownUntil;


    public void TryCapture(ICarrier candidate)
    {
        if (Time.time < _cooldownUntil) return;

        _cooldownUntil = Time.time + _targetObjectSettings.captureCooldown;
    }


    private void SetOwner(ICarrier newOwner)
    {
        CurrentOwner = newOwner;
        transform.SetParent(newOwner.CarryPoint, worldPositionStays: false);
    }
}
