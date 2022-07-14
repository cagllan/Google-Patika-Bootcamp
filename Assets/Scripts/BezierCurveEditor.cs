using UnityEngine;

public class BezierCurveEditor : MonoBehaviour
{
    [SerializeField] private Transform[] _curvePoints;    
    [Range(0.02f, 0.1f)] public float _tCoef = 0.05f;

    private Vector3 _gizmoPosition;


    private void OnDrawGizmos() 
    {
        for (float t = 0; t < 1; t += _tCoef)
        {            
            Gizmos.color = Color.red;            
            _gizmoPosition = GetBezierCurvePointByT(t, _curvePoints[0].position, _curvePoints[1].position, _curvePoints[2].position, _curvePoints[3].position);      
            Gizmos.DrawSphere(_gizmoPosition, 0.25f);
        }
    }

    public static Vector3 GetBezierCurvePointByT(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {        
        return Mathf.Pow(1 - t, 3f) * p0 + 3 * Mathf.Pow(1 - t, 2f) * t * p1 + 3 * (1 - t) * Mathf.Pow(t, 2) * p2 + Mathf.Pow(t, 3) * p3;    
    }
}
