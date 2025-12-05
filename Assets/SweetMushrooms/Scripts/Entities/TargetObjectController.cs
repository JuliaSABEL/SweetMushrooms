using System;
using UnityEngine;


public class TargetObjectController : MonoBehaviour
{
    public event Action OnOwnerChanged;
    
    public ICarrier CurrentOwner { get; private set; }
    
    [SerializeField] private TargetObjectSettings _targetObjectSettings;
    [SerializeField] private Rigidbody2D _rigidbody;

    private float _cooldownUntil;


    public void TryCapture(ICarrier candidate)
    {
        if (Time.time < _cooldownUntil) return;
        if (candidate == null || candidate == CurrentOwner) return;
        
        SetOwner(candidate);
        _cooldownUntil = Time.time + _targetObjectSettings.captureCooldown;
    }

    public void Detach()
    {
        CurrentOwner = null;
        transform.SetParent(null);
        _rigidbody.simulated = true;
    }


    private void Awake() => Detach();

    private void OnTriggerEnter2D(Collider2D other)
    {
        var carrier = other.GetComponentInParent<ICarrier>();
        if (carrier != null) TryCapture(carrier);
    }
    
    private void SetOwner(ICarrier newOwner)
    {
        CurrentOwner = newOwner;
        transform.SetParent(newOwner.CarryPoint, worldPositionStays: false);
        transform.localPosition = Vector3.zero;
        _rigidbody.simulated = false;
        OnOwnerChanged?.Invoke();
    }
}
