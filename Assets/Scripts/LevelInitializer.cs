using UnityEngine;

public class LevelInitializer : MonoBehaviour
{
    [SerializeField] private LevelDataSO levelData;
    private GameObject _star; 


    private void Start() 
    {
        _star = Instantiate(levelData.Star.CelestialPrefab, Vector3.zero, Quaternion.identity);

        foreach (var planet in levelData.Planets)
        {
            float randomTetha = Random.Range(0f, 360f);
            Vector3 randomOrbitPosition = _star.transform.position + GetRandomPositionOnOrbit(randomTetha, planet.DistanceToStar);
            var planetObject = Instantiate(planet.Planet.CelestialPrefab, randomOrbitPosition, Quaternion.identity);
            planetObject.GetComponent<OrbitMovement>().TargetObject = _star.transform;

            foreach(var satellite in planet.Satellites)
            {
                CreateSatellite(out randomTetha, out randomOrbitPosition, planetObject, satellite);
            }

        }
    }

    private static void CreateSatellite(out float randomTetha, out Vector3 randomOrbitPosition, GameObject planetObject, SatelliteData satellite)
    {
        randomTetha = Random.Range(0f, 360f);
        randomOrbitPosition = planetObject.transform.position + GetRandomPositionOnOrbit(randomTetha, satellite.DistanceToPlanet);
        var satelliteObject = Instantiate(satellite.Satellite.CelestialPrefab, randomOrbitPosition, Quaternion.identity);
        satelliteObject.transform.parent = planetObject.transform;
        satelliteObject.GetComponent<OrbitMovement>().TargetObject = planetObject.transform;
    }

    private static Vector3 GetRandomPositionOnOrbit(float tetha, float radius)
    {
        return new Vector3(Mathf.Cos(tetha * Mathf.Deg2Rad) * radius, 0, Mathf.Sin(tetha * Mathf.Deg2Rad) * radius);
    }


}
