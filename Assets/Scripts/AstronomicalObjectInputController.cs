using UnityEngine;
using System;

public class AstronomicalObjectInputController : MonoBehaviour
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

        AstronomicalObjectOnClickProcess();        
    }


    private void AstronomicalObjectOnClickProcess()
    {
        
        _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(_ray,out _hit, _maxDistance, _targetLayerMask))
        {
            
            OnObjectClicked?.Invoke(_hit.transform);
        }
    }
}
