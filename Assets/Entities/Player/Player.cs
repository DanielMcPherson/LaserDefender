using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    [SerializeField] float speed = 5f;
    [SerializeField] GameObject laser;
    [SerializeField] float laserSpeed = 10f;
    [SerializeField] float firingRate = 0.2f;
    [SerializeField] float health = 250; 
    [SerializeField] GameObject smokePrefab;
    [SerializeField] AudioClip hitSound;
    [SerializeField] AudioClip deadSound;
    float xMin, xMax;
    GameObject smoke = null;

    Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();

        float padding = GetComponent<SpriteRenderer>().bounds.extents.x;

        float cameraDistance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, cameraDistance));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, cameraDistance));
        xMin = leftMost.x + padding;
        xMax = rightMost.x - padding;

        smoke = null;
    }
    
    void Fire() {
        GameObject laz = Instantiate(laser, transform.position, Quaternion.identity) as GameObject;
        laz.GetComponent<Rigidbody2D>().velocity = laserSpeed * Vector3.up; 
    }

    // Update is called once per frame
    void Update () {
        // Check for movement
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector3 pos = rb.transform.position;
        pos.x = Mathf.Clamp(pos.x + moveX, xMin, xMax);
        rb.transform.position = pos;

        // Check for fire
        if (Input.GetButtonDown("Fire1")) {
            InvokeRepeating("Fire", .00000001f, firingRate);
        }
        if (Input.GetButtonUp("Fire1")) {
            CancelInvoke("Fire");
        }
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
            if (smokePrefab) {
                if (!smoke) {
                    smoke = Instantiate(smokePrefab, transform.position, Quaternion.identity) as GameObject;
                    smoke.transform.parent = transform;
                }
            }
            if (health <= 0f) {
                if (deadSound) {
                    AudioSource.PlayClipAtPoint(deadSound, transform.position);
                }
                Destroy(gameObject);
            } else {
                if (hitSound) {
                    print("Player hit");
                    AudioSource.PlayClipAtPoint(hitSound, transform.position);
                }
            }
        }
    }

}
