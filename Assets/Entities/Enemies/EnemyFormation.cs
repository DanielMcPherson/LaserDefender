using UnityEngine;
using System.Collections;

public class EnemyFormation : MonoBehaviour {

    [SerializeField] GameObject enemy;
    [SerializeField] float width = 10f;
    [SerializeField] float height = 5f;
    [SerializeField] float speed = 5f;
    float xMin, xMax;

    // Use this for initialization
    void Start ()
    {
        SpawnFormation();
        float cameraDistance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, cameraDistance));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, cameraDistance));
        xMin = leftMost.x + width / 2;
        xMax = rightMost.x - width / 2;
    }

    private void SpawnFormation() {
        if (enemy) {
            foreach (Transform child in transform) {
                GameObject thisEnemy = Instantiate(enemy, child.transform.position, Quaternion.identity) as GameObject;
                thisEnemy.transform.parent = child.transform;
            }
        }
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

        // See if all the enemies in this formation are dead
        if (AllMembersDead()) {
            print("All enemies are dead");
            SpawnFormation();
        }
    }

    bool AllMembersDead() {
        // Loop through all of the child transforms of the formation.
        // Each chlld will either have an enemy child of its own,
        // or will have no children.
        foreach (Transform enemyPosition in transform) {
            if (enemyPosition.childCount > 0) {
                // Found an enemy in this position. Not all dead.
                return false;
            }
        }
        // Didn't find any child transforms that contained an enemy.
        // All enemies are dead.
        return true;
    }
}
