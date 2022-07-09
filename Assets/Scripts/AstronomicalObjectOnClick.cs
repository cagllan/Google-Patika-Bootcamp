using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronomicalObjectOnClick : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] LayerMask _targetLayerMask;

    [SerializeField] float _maxDistance;

    
    
    Ray _ray;
    RaycastHit _hit;
    

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
            if(_hit.transform != null)
            {
                Debug.Log(_hit.transform.gameObject.name);
            }
        }
    }
}
