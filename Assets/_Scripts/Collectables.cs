using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    // Start is called before the first frame update
<<<<<<< Updated upstream
    public int score;

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player")
        {
            //ScoreManager.scoremanager.UpdateScore(score);
            Debug.Log("Collided!");
=======
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player"){
            Debug.Log("collided");
>>>>>>> Stashed changes
            Destroy(gameObject);

        }
    }
}
