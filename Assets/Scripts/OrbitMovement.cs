using System.Collections;
using UnityEngine;

public class OrbitMovement : MonoBehaviour
{
    [SerializeField] private Transform _targetObject;
    [SerializeField] private float _speedAmount;
    private float _fullRotationAngle = 360f;
    private IEnumerator _rotationRoutine;

    private void Start()
    {
        StartOrbitalRotationRoutine();
    }

    private void OnDestroy() 
    {
        StopOrbitalRotationRoutine();
    }

    public void StartOrbitalRotationRoutine()
    {
        StopOrbitalRotationRoutine();
        
        _rotationRoutine = OrbitalRotationProgress();

        StartCoroutine(_rotationRoutine);
    }

    public void StopOrbitalRotationRoutine()
    {
        
        if(_rotationRoutine != null)
        {
            StopCoroutine(_rotationRoutine);
        }
        
    }
    
    private IEnumerator OrbitalRotationProgress()
    {
        float totalAngle = 0;
        while(true)
        {            
            transform.RotateAround(_targetObject.position, Vector3.up, _speedAmount * Time.deltaTime);
            totalAngle += _speedAmount * Time.deltaTime;

            if(totalAngle >= _fullRotationAngle)
            {
                WriteToConsolePlanetName(gameObject.name);
                totalAngle = 0;
            }

            yield return new WaitForEndOfFrame();
        }
    }


    private void WriteToConsolePlanetName(string planetName)
    {
        Debug.Log($"{planetName} has completed its full rotation.");
    }
}
