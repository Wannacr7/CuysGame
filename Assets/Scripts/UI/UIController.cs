using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]GameManager gameController;

    [SerializeField]GameObject winPanel;
    [SerializeField]Text winName;
    private void Start() {
        Time.timeScale=0;
        winPanel.SetActive(false);
    }

    private void OnEnable() {
        gameController.OnWinnerReady+=ActivateWinPanel;
    }
    private void OnDisable() {
        gameController.OnWinnerReady-=ActivateWinPanel;
    }


    private void ActivateWinPanel(TypeCuy colorCuy){
        switch (colorCuy){
            case TypeCuy.Amarillo:
            winName.text = "Cuy amarillo";
            break;
            case TypeCuy.Cafe:
            winName.text = "Cuy cafe";
            break;
            case TypeCuy.Rojo:
            winName.text = "Cuy rojo";
            break;     
        }
        winPanel.SetActive(true);
    }

    public void RestartGame(){
        SceneManager.LoadScene("SampleScene");
    }
    public void StartTime(){
        Time.timeScale=1;
    }
    





}
