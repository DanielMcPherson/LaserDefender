using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public float health = 250;

    // Use this for initialization
    void Start () {
    
    }
    
    // Update is called once per frame
    void Update () {
    
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        Projectile laser = other.GetComponent<Projectile>();
        if (laser) {
            health -= laser.GetDamage();
            laser.Hit();
            if (health <= 0f) {
                Destroy(gameObject);
            }
        }
    }
}
