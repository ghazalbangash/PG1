using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    
    public string nameCollectable;
    public int score;
    public int restoreHP;

    public Collectables(string name, int scorevalue, int restoreHPvalue)
    {
        this.nameCollectable = name;
        this.score = scorevalue;
        this.restoreHP = restoreHPvalue;
    }

    public void UpdateScore()
    {
        ScoreManager.scoremanager.UpdateScore(score);
    }

    public void UpdateHealth()
    {
        
    } 
    //     private void OnCollisionEnter(Collision other) {
    //     if(other.gameObject.tag == "Player"){
    //         Debug.Log("Collided");
    //         Destroy(gameObject);
    //     }
        
    // }
}
