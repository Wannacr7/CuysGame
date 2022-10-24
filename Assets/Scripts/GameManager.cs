using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityAction<TypeCuy> OnWinnerReady;

    [SerializeField]private CuysStats stats;
    [Header("Gen speed range for Cuyes")]
    [SerializeField]private float minRange=1;
    [SerializeField]private float maxRange=6;
    [Header("Offset for Cuyes rails")]
    [SerializeField]private float[] offSetRail;
    [Header("Countdown to change speed")]
    [SerializeField]private float timer;

    //to set speeds
    private int indexToSetSpeed;
    //to check winner
    private bool isPlaying;
    private bool waitWinner;
    private int numplayer;
    //to manage Timer
    private float counter;



    // Start is called before the first frame update
    void Start()
    {
        ResetStats();
        indexToSetSpeed=0;
        isPlaying=false;
        waitWinner=true;
        numplayer=0;
        counter=timer;

    }

    // Update is called once per frame
    void Update()
    {
        if(counter>0){
            counter-=Time.deltaTime;
        }
        else{
            SetSpeeds();
            counter=timer;  
            
            Debug.Log("SPEED HAS CHANGED");
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.CompareTag("Cuyes")){
            

            if(numplayer==3){
                isPlaying=true;
                
            }
            if(isPlaying){
                if(waitWinner){
                    Debug.Log(other.GetComponent<CuyManager>().colorCuy);
                    OnWinnerReady?.Invoke(other.GetComponent<CuyManager>().colorCuy);
                    waitWinner=false;
                    numplayer=1;
                }
                
                if(numplayer==3)Time.timeScale=0;
            }
            numplayer++;

            

        }
    }


    public void SetSpeeds(){
        foreach (var f in offSetRail)
        {
            float tempRnd = Random.Range(minRange,maxRange);

            if(indexToSetSpeed==0)stats.amarilloVelocity = tempRnd+f;
            if(indexToSetSpeed==1)stats.cafeVelocity = tempRnd+f;
            if(indexToSetSpeed==2)stats.rojoVelocity = tempRnd+f;
            indexToSetSpeed++;
            
            
        }
        indexToSetSpeed=0;
    }
    private void ResetStats(){
        stats.amarilloVelocity = 0;
        stats.cafeVelocity = 0;
        stats.rojoVelocity = 0;

    }
    
}
