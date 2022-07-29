using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Scriptable Objects/Level Data/Level")]
public class LevelDataSO : ScriptableObject
{
    public StarDataSO Star;
    public List<PlanetData> Planets;
}

[System.Serializable]  
public class PlanetData
{

    public PlanetDataSO Planet;

    public float DistanceToStar;


    public List<SatelliteData> Satellites;
}

[System.Serializable]
public class SatelliteData
{
    public SatelliteDataSO Satellite;
    public float DistanceToPlanet;
}
