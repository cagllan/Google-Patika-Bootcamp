using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorParticleSystem : MonoBehaviour
{
    [SerializeField] ParticleSystem explodedEffect;

    public void PlayExplodedEffect()
    {
        explodedEffect.Play();
    }
}
