using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {
    // public
    public static GameManager Instance;
    public int Health = 100;
    public int Score = 0;
    public GameObject Player;
    public TMP_Text Text_Score;

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

    public void DisplayScore(){
        Text_Score.text = Score.ToString();
    }
    public void SetupPlayer(){
        Health = 100;
        Score = 0;
        DisplayScore();
    }
    public void UpdateHealth(int amount, bool isIncrease){
        if(isIncrease) Health += amount;
        else Health -= amount;
        Debug.Log("Health : " + Health);
        if(Health <= 0) Player.GetComponent<PlayerController>().isAlive = false;
    }
    public void UpdateScore(int amount){
        Score += amount;
        DisplayScore();
    }
}
