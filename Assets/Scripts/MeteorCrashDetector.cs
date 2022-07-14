using UnityEngine;
using System;

public class MeteorCrashDetector : MonoBehaviour
{
    [SerializeField] private ParticleSystem _crashParticle;

    public Action OnMeteorCrashed { get; set; }
    

    private void OnCollisionEnter(Collision other) 
    {
        ContactPoint contact = other.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;
       
        _crashParticle.transform.position = pos;
        _crashParticle.transform.SetParent(other.gameObject.transform,true);
        _crashParticle.Play();

        OnMeteorCrashed?.Invoke();

    }
}



