using UnityEngine;
using System.Collections;
using System;

public class Meteor : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explodedEffect;

    private MeteorCrashDetector _meteorCrashDetector;
    private IEnumerator _destroyMeteorRoutine;

    public Action OnMeteorDestroying { get;set; }

    private void Awake() 
    {
        _meteorCrashDetector = GetComponent<MeteorCrashDetector>();
        _meteorCrashDetector.OnMeteorCrashed += OnMeteorCrashed;
    }

    private void Start() 
    {
        StartDestroyMeteorRoutine();
    }

    private void OnDestroy() 
    {
        _meteorCrashDetector.OnMeteorCrashed -= OnMeteorCrashed;
    }

    public void DestroyMeteor()
    {  
        _explodedEffect.transform.SetParent(null);
        _explodedEffect.Play();
        OnMeteorDestroying?.Invoke();
        GameObject.Destroy(gameObject);        
    }

    private void OnMeteorCrashed()
    {
        _meteorCrashDetector.OnMeteorCrashed -= OnMeteorCrashed;
        DestroyMeteor();        
    }

    public void StartDestroyMeteorRoutine()
    {
        StopDestroyMeteorRoutine();

        _destroyMeteorRoutine = DestroyMeteorProgress();
        StartCoroutine(_destroyMeteorRoutine);
    }

    public void StopDestroyMeteorRoutine()
    {
        if(_destroyMeteorRoutine != null)
        {
            StopCoroutine(_destroyMeteorRoutine);
            _destroyMeteorRoutine = null;
        }
    }
    private IEnumerator DestroyMeteorProgress()
    {
        yield return new WaitForSeconds(5);
        DestroyMeteor();
    }
}
