using UnityEngine;
using TMPro;

public class AstoronomicalObjectInfoCanvas : MonoBehaviour 
{
    [SerializeField] private Canvas _uiCanvas;
    [SerializeField] private TMP_Text _textTMPAstronomicalObjectName;
    [SerializeField] private AstronomicalObjectInputController _astronomicalObjectInputController;


    private void Awake() 
    {        
        _astronomicalObjectInputController.OnObjectClicked += OnObjectClicked;
        DisableCanvas();
    }

    private void OnDestroy() 
    {
        _astronomicalObjectInputController.OnObjectClicked -= OnObjectClicked;
    }

    public void DisableCanvas()  
    {
        _uiCanvas.gameObject.SetActive(false);
    }


    private void EnableCanvas()
    {
       _uiCanvas.gameObject.SetActive(true);
    }

    private void SetAstronomicalObjectName(string text)
    {
       
        _textTMPAstronomicalObjectName.text = text;
    }

    private void OnObjectClicked(Transform transform)
    {
        EnableCanvas();
        SetAstronomicalObjectName(transform.gameObject.name);        
    }
}
