using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisMovement : MonoBehaviour
{
    [SerializeField] private float _speedAmount;
    private IEnumerator _rotationRoutine;
    void Start()
    {
        StartAxesRotationRoutine();
    }

    private void OnDestroy() 
    {
        StopAxesRotationRoutine();        
    }

    private void StartAxesRotationRoutine()
    {
        StopAxesRotationRoutine();

        _rotationRoutine = AxisRotationProgress();

        StartCoroutine(_rotationRoutine);
    }

    private void StopAxesRotationRoutine()
    {
       if(_rotationRoutine != null)
       {
            StopCoroutine(AxisRotationProgress());
       }
    }
    
   private IEnumerator AxisRotationProgress()
   {
    while(true)
    {
        transform.Rotate(Vector3.up * _speedAmount* Time.deltaTime, Space.Self);
        yield return new WaitForEndOfFrame();
    }
   }
}
