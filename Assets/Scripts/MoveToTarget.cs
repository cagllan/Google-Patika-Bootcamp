using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    [SerializeField] private Transform _targetObject;
    [SerializeField] private float _speedConf;


    private Vector3 _distanceToTarget;
    private Rigidbody _rigidbody;

    private void Awake() 
    {
        _rigidbody = GetComponent<Rigidbody>();
        _targetObject = PlanetManager.Instance.GetRandomPlanet().transform;
    }

    private void Update() 
    {
        if(!_targetObject) return; 

        _distanceToTarget = _targetObject.position - transform.position;
        _distanceToTarget.Normalize();
        _rigidbody.AddForce(_distanceToTarget * _speedConf);
    }

    private void OnDrawGizmos() 
    {
        if(_targetObject == null) return;

         Gizmos.color = Color.green;        
         Gizmos.DrawLine(_targetObject.position, transform.position + _distanceToTarget);
    }
}
