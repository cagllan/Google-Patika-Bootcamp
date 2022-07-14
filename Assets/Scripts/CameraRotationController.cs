using System.Collections;
using UnityEngine;

public class CameraRotationController : MonoBehaviour
{
    [SerializeField] Canvas _uiCanvas;

    private OrbitMovement _orbitMovement;
    private IEnumerator _idleRotationRoutine;


    private void Awake() 
    {
        _orbitMovement = GetComponent<OrbitMovement>();
    }


    private void Update() 
    {  
        if(CheckHorizantalMouseMovement())
        {
            StopIdleRotateRoutine();
            _orbitMovement.StopOrbitalRotationRoutine();           
            return;
        }

        if(CheckVerticalMouseMovement())
        {
            StopIdleRotateRoutine();
            _orbitMovement.StopOrbitalRotationRoutine();               
            return;
        }

        if(_uiCanvas.gameObject.activeSelf == true)
        {
            
            StopIdleRotateRoutine();
            _orbitMovement.StopOrbitalRotationRoutine();
            return; 
        }

        if(_idleRotationRoutine == null)
        {
            StartIdleRotateRoutine();
        }        
    }


    private void StartIdleRotateRoutine()
    {
        StopIdleRotateRoutine();
        _idleRotationRoutine = IdleRotateProgress();
        StartCoroutine(_idleRotationRoutine);
    }


    private void StopIdleRotateRoutine()
    {
        if(_idleRotationRoutine != null)
       {
            StopCoroutine(_idleRotationRoutine);
            _idleRotationRoutine = null;
       }            
    }


    private IEnumerator IdleRotateProgress()
    {
        yield return new WaitForSeconds(3);
        _orbitMovement.StartOrbitalRotationRoutine();
    }


    private bool CheckHorizantalMouseMovement()
    {
        float horizontal = Input.GetAxis("Mouse X");
        horizontal = Mathf.Abs(horizontal);
        return horizontal > 0;
    }


    private bool CheckVerticalMouseMovement()
    {
        float vertical = Input.GetAxis("Mouse Y");
        vertical = Mathf.Abs(vertical);
        return vertical > 0;
    }
}
