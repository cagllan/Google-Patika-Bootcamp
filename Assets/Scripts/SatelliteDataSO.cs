using UnityEngine;

[CreateAssetMenu(fileName = "Satellite", menuName = "Scriptable Objects/Satellite Scriptable Object")]
public class SatelliteDataSO : CelestialDataSO
{
    [SerializeField] float _orbitRadius;

    private Transform _parentPlanet;

    private GameObject _satellite;


    public override string ToString()
    {
      return $"{CelestialName} - {CelestialDescription} - {Radius} - {CelestialPrefab.name}";
    }


}
