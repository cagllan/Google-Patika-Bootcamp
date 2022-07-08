using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnBezier : MonoBehaviour
{
    [SerializeField] private Transform[] _bezierCurve;

    [SerializeField] private float _speedCoef = 1;

    private int _runningBezierCurveNo=0;
    private void Start()
    {
        StartCoroutine(MoveOnBezierRoute());
    }


    private IEnumerator MoveOnBezierRoute()
    {        
        Vector3 positionToGo = transform.position;        
        float t = 0f;
        
        while(t <= 1)
        {           
            t += Time.deltaTime * _speedCoef;
            
            positionToGo = BezierCurveEditor.GetBezierCurvePointByT(t, _bezierCurve[_runningBezierCurveNo].GetChild(0).position, _bezierCurve[_runningBezierCurveNo].GetChild(1).position, _bezierCurve[_runningBezierCurveNo].GetChild(2).position, _bezierCurve[_runningBezierCurveNo].GetChild(3).position);

            
            transform.position = positionToGo;

            yield return new WaitForEndOfFrame();
        }
        
        _runningBezierCurveNo++;        

        if(_runningBezierCurveNo >= _bezierCurve.Length)
        {
            WriteToConsolePlanetName(gameObject.name);
            _runningBezierCurveNo = 0;
        }        

        StartCoroutine(MoveOnBezierRoute());
        yield break;
    }


    private void WriteToConsolePlanetName(string planetName)
    {
        Debug.Log($"{planetName} has completed its full rotation.");
    }
}
