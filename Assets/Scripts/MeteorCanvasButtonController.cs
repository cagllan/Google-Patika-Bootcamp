using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class MeteorCanvasButtonController : MonoBehaviour
{
    [SerializeField] private Button _meteorButton;
    [SerializeField] private TMP_Text _meteorButtonText;

    [SerializeField] private MeteorSpawner _meteorSpawner;


    private void Start() {
        _meteorSpawner.OnMeteorSpawned += OnMeteorSpawn;
        _meteorSpawner.OnMeteorDespawned += OnMeteorDespawn;
    }

    private void OnDestroy() {
        _meteorSpawner.OnMeteorSpawned -= OnMeteorSpawn;
        _meteorSpawner.OnMeteorDespawned -= OnMeteorDespawn;
    }

    private void OnMeteorSpawn()
    {
        _meteorButtonText.text = "Destroy Meteor";
    }

    private void OnMeteorDespawn()
    {        
        _meteorButtonText.text = "Create Meteor";
    }

    public void OnButtonClicked()
    {
        if(_meteorSpawner.IsMeteorActive)
        {
            _meteorSpawner.ActiveMeteor.DestroyMeteor();
            return;
        }
        
            _meteorSpawner.SpawnMeteor();      
    }

}
