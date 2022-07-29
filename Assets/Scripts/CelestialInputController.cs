using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class CelestialInputController : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private LayerMask _targetLayerMask;
    [SerializeField] private float _maxDistance;
  
    private Ray _ray;
    private RaycastHit _hit;

    public Action<Transform> OnObjectClicked { get; set; }    
   
    private void Update() 
    {
        if(!Input.GetMouseButtonDown(0)) return;

        CelestialOnClickProcess();        
    }


    private void CelestialOnClickProcess()
    {
        bool currentEvent = EventSystem.current.IsPointerOverGameObject();

        if (currentEvent) return;


        _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(_ray,out _hit, _maxDistance, _targetLayerMask))
        {
            OnObjectClicked?.Invoke(_hit.transform);
        }
    }
}
