using UnityEngine;


public enum EnemyState
{
    SeekTarget,
    FleeWithObject,
    ChaseHolder
}

public class EnemyController : MonoBehaviour
{
    [SerializeField] private TargetObjectController _target;
    [SerializeField] private EnemyCarrier _carrier;
    
    private EnemyState _state;

    
    private void OnEnable()
    {
        _target.OnOwnerChanged += RecalculateState;
        RecalculateState();
    }

    private void OnDisable()
    {
        _target.OnOwnerChanged -= RecalculateState;
    }

    private void RecalculateState()
    {
        if (_target.CurrentOwner == null)
            _state = EnemyState.SeekTarget;
        else if (_target.CurrentOwner == _carrier)
            _state = EnemyState.FleeWithObject;
        else if (_target.CurrentOwner is PlayerCarrier)
            _state = EnemyState.ChaseHolder;
        else
            _state = EnemyState.SeekTarget;
    }

    // private Vector2 DirectionTo(){}
}
