﻿using UnityEngine;
using System.Collections;

public class EnemyFormation : MonoBehaviour {

    [SerializeField] GameObject enemy;
    [SerializeField] float width = 10f;
    [SerializeField] float height = 5f;
    [SerializeField] float speed = 5f;
    float xMin, xMax;

    // Use this for initialization
    void Start () {
        if (enemy) {
            foreach (Transform child in transform) {
                GameObject thisEnemy = Instantiate(enemy, child.transform.position, Quaternion.identity) as GameObject;
                thisEnemy.transform.parent = child.transform;                
            }
        }
        float cameraDistance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, cameraDistance));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, cameraDistance));
        xMin = leftMost.x + width / 2;
        xMax = rightMost.x - width / 2;
    }
    
    /// <summary>
    /// Callback to draw gizmos that are pickable and always drawn.
    /// </summary>
    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
    }
    // Update is called once per frame
    void Update () {
        transform.position += speed * Time.deltaTime * Vector3.right;
        if (speed > 0 && transform.position.x > xMax) {
            speed *= -1;
        } else if (speed < 0 && transform.position.x < xMin) {
            speed *= -1;
        }
    }
}