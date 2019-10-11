using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardJump : MonoBehaviour
{

    // SCRIPT ADDS ADDITIONAL REWARD ZONE TO PLATFORMS AND SPIKES


    public int scoreToGive;

    private ScoreManager theScoreManager;

    // Start is called before the first frame update
    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            theScoreManager.AddScore(scoreToGive);
        }
    }
}
