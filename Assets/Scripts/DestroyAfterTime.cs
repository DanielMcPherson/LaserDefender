using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour {

    [SerializeField] float destroyTime = 2f;
    // Use this for initialization
    void Start () {
        Destroy(gameObject, destroyTime);
    }
}
