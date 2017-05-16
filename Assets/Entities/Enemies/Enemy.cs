using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    [SerializeField] GameObject laser;
    [SerializeField] float laserSpeed = 10f;
    [SerializeField] float shotsPerSecond = 0.5f;
    public float health = 250;

    Animator anim;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update ()
    {
        // Probability of firing on this frame
        float probability = Time.deltaTime * shotsPerSecond;
        if (Random.value < probability) {
            Fire();
        }
    }

    private void Fire()
    {
        GameObject laz = Instantiate(laser, transform.position, Quaternion.identity) as GameObject;
        laz.GetComponent<Rigidbody2D>().velocity = laserSpeed * Vector3.down;
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
            if (anim) {
                anim.SetTrigger("Hit");
            }
            if (health <= 0f) {
                Destroy(gameObject);
            }
        }
    }
}
