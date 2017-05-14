using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
/// <summary>
/// Callback to draw gizmos that are pickable and always drawn.
/// </summary>
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }
}
