using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Planet", menuName = "Scriptable Objects/Planet Scriptable Object")]
public class PlanetDataSO : CelestialDataSO
{
    public long Population;

    public List<SatelliteDataSO> Satellites;

    public override string ToString()
    {
      return $"{CelestialName} - {CelestialDescription} - {Radius} - {Population}";
    }


}
