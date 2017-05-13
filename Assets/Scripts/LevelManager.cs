using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string level) {
        Application.LoadLevel(level);
    }

    public void LoadNextLevel() {
        Application.LoadLevel(Application.loadedLevel + 1);
    }
    
    public void Quit() {
        print("User asked to quit");
        //Application.Quit();
    }
}
