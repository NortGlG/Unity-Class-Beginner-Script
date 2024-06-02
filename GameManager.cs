using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {
    // public
    public static GameManager Instance;
    public int Health = 100;
    public int Score = 0;
    public GameObject Player;
    public TMP_Text Text_Score;
    public Image HealthBar;

    // private
    private int MaxHealth;

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
    public void DisplayHealth(){ // Change this up to your desire :)
        float current = 1f * Health / MaxHealth;
        HealthBar.fillAmount = current;
    }
    public void SetupPlayer(){
        Health = 100;
        Score = 0;
        MaxHealth = Health;
        DisplayScore();
        DisplayHealth();
    }
    public void UpdateHealth(int amount, bool isIncrease){
        if(isIncrease) Health += amount;
        else Health -= amount;
        DisplayHealth();
        if(Health <= 0) {
            Player.GetComponent<PlayerController>().isAlive = false;
        }
    }
    public void UpdateScore(int amount){
        Score += amount;
        DisplayScore();
    }
}
