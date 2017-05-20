using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreDisplay : MonoBehaviour {

    // Use this for initialization
    void Start () {
        Text text = GetComponent<Text>();
        if (text) {
            int score = ScoreKeeper.GetScore();
            text.text = "Score: " + score.ToString();
            ScoreKeeper.Reset();
        }
    }
    
    // Update is called once per frame
    void Update () {
    
    }
}
