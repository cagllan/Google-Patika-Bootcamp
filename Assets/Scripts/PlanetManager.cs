using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    private static PlanetManager _instance;

    public static PlanetManager Instance 
    { 
        get 
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<PlanetManager>();
            }
            return _instance;
        }
    }


    private  Planet[] _planets;

    private   Planet[] _Planets
    { 
        get 
        {
            if(_planets == null)
            {
                _planets = FindObjectsOfType<Planet>();
            }
            return _planets;
        }
    }


    public Planet GetRandomPlanet()
    {
        return _Planets[Random.Range(0, _Planets.Length-1)];
    } 
}
