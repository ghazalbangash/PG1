using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;

    private void OnCollisionEnter(Collision other) {
        Debug.Log(other.gameObject.tag);
        if(other.gameObject.tag == "Player")
        {
            //ScoreManager.scoremanager.UpdateScore(score);
            Debug.Log("Collided!");
            Destroy(gameObject);
        }
    }
}
