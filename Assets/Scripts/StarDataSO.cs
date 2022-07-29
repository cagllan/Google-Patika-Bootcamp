using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Star", menuName = "Scriptable Objects/Star Scriptable Object")]
public class StarDataSO : CelestialDataSO
{
    [SerializeField] Vector3 _initializePosition;

    public float RotationSpeed;
    public Vector3 InitializePosition { get {return _initializePosition;}}

    public List<PlanetDataSO> Planets;

}
