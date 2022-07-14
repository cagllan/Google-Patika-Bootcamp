using System.Collections;
using UnityEngine;
using System;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] private Meteor _spawnObject;
    [SerializeField] private float _minSpawnDistance;
    [SerializeField] private float _maxSpawnDistance;
    

    private Meteor _clone;

    public Meteor ActiveMeteor => _clone;
    private IEnumerator _destroyMeteorRoutine;

    public bool IsMeteorActive { get; private set;}


    public Action OnMeteorSpawned { get; set;}
    public Action OnMeteorDespawned {get; set; }
   
    private void Start() 
    {     
       SpawnMeteor();
    }

    private void OnDestroy()   
    {
        _clone.OnMeteorDestroying -= OnMeteorDestroying;
    }


    public void SpawnMeteor() 
    {        

        Vector3 spawnObjectPosition = UnityEngine.Random.insideUnitCircle.normalized * UnityEngine.Random.Range(_minSpawnDistance, _maxSpawnDistance);
        _clone = Instantiate(_spawnObject, spawnObjectPosition, Quaternion.identity);
        _clone.transform.SetParent(gameObject.transform, true);
        IsMeteorActive = true;

        _clone.OnMeteorDestroying += OnMeteorDestroying;

        OnMeteorSpawned?.Invoke(); 
    }

    private void OnMeteorDestroying()
    {      
        IsMeteorActive = false;
        _clone.OnMeteorDestroying -= OnMeteorDestroying;
        OnMeteorDespawned?.Invoke();
    }

}


