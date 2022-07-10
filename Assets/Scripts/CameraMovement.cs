using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private OrbitMovement _orbitMovement;

    [SerializeField] Canvas _uiCanvas;

    private IEnumerator _autoRotationRoutine;


    private void Awake() 
    {
        _orbitMovement = GetComponent<OrbitMovement>();
    }



    private void Update() 
    {

        
        

        if(CheckHorizantalMouseMovement())
        {
            StopAutoRotateRoutine();
            _orbitMovement.StopOrbitalRotationRoutine();
           
            return;
        }

        if(CheckVerticalMouseMovement())
        {
            StopAutoRotateRoutine();
            _orbitMovement.StopOrbitalRotationRoutine();
           
            
            return;
        }


        if(_uiCanvas.gameObject.activeSelf == true)
        {
            StopAutoRotateRoutine();
            _orbitMovement.StopOrbitalRotationRoutine();
       

            return; 
        }


        if(_autoRotationRoutine == null)
        {
            StartAutoRotateRoutine();
        }
        
            
                
           
            
            
        



            
            
        

        
    }




    private void StartAutoRotateRoutine()
    {
        StopAutoRotateRoutine();

        _autoRotationRoutine = AutoRotateProgress();

        StartCoroutine(_autoRotationRoutine);
    }


    private void StopAutoRotateRoutine()
    {

        if(_autoRotationRoutine != null)
       {
            StopCoroutine(_autoRotationRoutine);
            _autoRotationRoutine = null;
       }
            
    }


    private IEnumerator AutoRotateProgress()
    {
        yield return new WaitForSeconds(3);
        _orbitMovement.StartOrbitalRotationRoutine();
    }


    private bool CheckHorizantalMouseMovement()
    {
        float horizontal = Input.GetAxis("Mouse X");  

        horizontal = Mathf.Abs(horizontal);

        if(horizontal >0 )
        {
            return true;
        }

        return false;
    }


    private bool CheckVerticalMouseMovement()
    {
        float vertical = Input.GetAxis("Mouse Y");  

        vertical = Mathf.Abs(vertical);

        if(vertical>0 )
        {
            return true;
        }

        return false;
    }
}
