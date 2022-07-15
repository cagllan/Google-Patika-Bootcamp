using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MeteorCreationButtonController : MonoBehaviour
{
    [SerializeField] private Button _meteorCreationButton;
    [SerializeField] private TMP_Text _meteorCreationButtonText;

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
        _meteorCreationButtonText.text = "Destroy Meteor";
    }

    private void OnMeteorDespawn()
    {        
        _meteorCreationButtonText.text = "Create Meteor";
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
