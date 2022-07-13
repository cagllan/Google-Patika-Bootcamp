using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _spawnObject;
    [SerializeField] private float _minSpawnDistance;
    [SerializeField] private float _maxSpawnDistance;
    [SerializeField] private TMP_Text _meteorButtonText;


    private GameObject _clone;
    private IEnumerator _destroyMeteorRoutine;


    private void Start() 
    {        
        MeteorCreateAndDestroyProgress();
    }


    private void CreateMeteor()
    {        
        StartDestroyMeteorRoutine();

        Vector3 spawnObjectPosition =  Random.insideUnitCircle.normalized * Random.Range(_minSpawnDistance, _maxSpawnDistance);
        _clone = Instantiate(_spawnObject, spawnObjectPosition, Quaternion.identity);
        _clone.transform.SetParent(gameObject.transform, true);
        _meteorButtonText.text = "Destroy Meteor";
    }

    public void DestroyMeteor()
    {       
            if(_clone != null)
            {
            _clone.GetComponent<MeteorParticleSystem>().PlayExplodedEffect();
             Destroy(_clone, 1f);
            _meteorButtonText.text = "Create Meteor";
            }
    }

    public void MeteorCreateAndDestroyProgress()
    {

        if(_clone == null)
        {
            CreateMeteor();
            return;
        }
        
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


