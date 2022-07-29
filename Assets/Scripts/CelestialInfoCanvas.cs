using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CelestialInfoCanvas : MonoBehaviour 
{
    [SerializeField] Button _closeButton;
    [SerializeField] private Canvas _uiCanvas;
    [SerializeField] private TMP_Text _textTMPCelestialName;
    [SerializeField] private CelestialInputController _celestialInputController;


    private void Awake() 
    {        
        _celestialInputController.OnObjectClicked += OnObjectClicked;
        _closeButton.onClick.AddListener(DisableCanvas);
        DisableCanvas();
    }

    private void OnDestroy() 
    {
        _celestialInputController.OnObjectClicked -= OnObjectClicked;
        _closeButton.onClick.RemoveListener(DisableCanvas);
    }

    private void OnObjectClicked(Transform transform)
    {
        EnableCanvas();
        SetCelestialName(transform.gameObject.name);        
    }

    public void DisableCanvas()  
    {
        _uiCanvas.gameObject.SetActive(false);
    }


    private void EnableCanvas()
    {
       _uiCanvas.gameObject.SetActive(true);
    }

    private void SetCelestialName(string text)
    {
       
        _textTMPCelestialName.text = text;
    }

    
}
