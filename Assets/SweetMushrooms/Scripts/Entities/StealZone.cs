using UnityEngine;


public class StealZone : MonoBehaviour
{
    [SerializeField] private TargetObjectController _target;
    [SerializeField] private MonoBehaviour _carrierBehaviour;

    private ICarrier _carrier;


    private void Awake() => _carrier = _carrierBehaviour as ICarrier;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var otherCarrier = other.GetComponentInParent<ICarrier>();
        if (otherCarrier == null) return;
        
        if (_target.CurrentOwner != _carrier && _target.CurrentOwner != otherCarrier) return;
        
        _target.TryCapture(_carrier);
        _target.TryCapture(otherCarrier);
    }
}
