using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

    static int score = 0;
    Text text;

    public static void Reset() {
        score = 0;
   }

    public static int GetScore() {
        return score;
    }

    public void Score(int points) {
        score += points;
        if (text) {
            text.text = score.ToString();
        }
    }

    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();
        Reset();
    }
    
    // Update is called once per frame
    void Update () {
    
    }
}
