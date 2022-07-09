using UnityEngine;
using TMPro;

public class AstronomicalObjectCanvasEditor : MonoBehaviour
{
    [SerializeField] Canvas _uiCanvas;

    [SerializeField] TMP_Text _textTMPAstronomicalObjectName;

    private void Start() 
    {
        DisableCanvas();
    }

    public void DisableCanvas()
    {
        _uiCanvas.gameObject.SetActive(false);
    }


    public void EnableCanvas()
    {
       _uiCanvas.gameObject.SetActive(true);
    }

    public void SetAstronomicalObjectName(string text)
    {
        _textTMPAstronomicalObjectName.text = text;
    }
}
