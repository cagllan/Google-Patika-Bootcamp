using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetExplosionParticle : MonoBehaviour
{
    [SerializeField] ParticleSystem _planetExplosionParticle;

    public ParticleSystem GetPlanetExplosionParticle()
    {
        return _planetExplosionParticle;
    }
}
