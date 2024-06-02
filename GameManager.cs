using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    // public
    public static GameManager Instance;
    public int Health = 100;
    public int Score = 0;
    
    // private

    // Start Here
    private void Awake(){
        if(Instance == null){
            Instance = this;
        }
        else{
            Destroy(Instance);
        }
    }

    private void Start(){
        SetupPlayer();
    }

    public void SetupPlayer(){
        Health = 100;
        Score = 0;
    }

    public void UpdateHealth(int amount){
        Health += amount;
        Debug.Log("Health : " + Health);
    }
    public void UpdateScore(int amount){
        Score += amount;
        Debug.Log("Score : " + Score);
    }
}
