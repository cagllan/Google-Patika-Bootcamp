using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorCrashDetector : MonoBehaviour
{
    private MeteorParticleSystem explodedEffect;
    private MeteorSpawner _meteorSpawner;
    private PlanetExplosionParticle _planetExplosionParticle;
    private PlanetExplosionParticle _clone;
    private void Awake() 
    {
        _meteorSpawner = FindObjectOfType<MeteorSpawner>();
        _planetExplosionParticle = FindObjectOfType<PlanetExplosionParticle>();        
    }

    private void OnCollisionEnter(Collision other) 
    {
        ContactPoint contact = other.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;

        _clone = Instantiate(_planetExplosionParticle, pos, rot);        
        _clone.transform.SetParent(other.gameObject.transform,true);        
        _clone.GetPlanetExplosionParticle().Play();
        
        _meteorSpawner.DestroyMeteor();
    }
}
