using System.Collections;
using UnityEngine;

public class LocalAxisRotation : MonoBehaviour
{
    [SerializeField] SpeedProviderBase _speedProvider;
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
            transform.Rotate(Vector3.up * _speedProvider.GetSpeed() * Time.deltaTime, Space.Self);
            yield return new WaitForEndOfFrame();
        }
   }
}
