using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

    static MusicPlayer instance = null;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        if (instance != null) {
            Destroy(gameObject);
        } else {
            GameObject.DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }
}
