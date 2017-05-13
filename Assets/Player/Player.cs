using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    [SerializeField] float speed = 5f;
    float xMin, xMax;

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
    }
    
    // Update is called once per frame
    void Update () {
        Vector3 pos = rb.transform.position;
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x + moveX, xMin, xMax);
        rb.transform.position = pos;
    }
}
