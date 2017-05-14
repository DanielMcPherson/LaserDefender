using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {
	/// <summary>
	/// Sent when another object enters a trigger collider attached to this
	/// object (2D physics only).
	/// </summary>
	/// <param name="other">The other Collider2D involved in this collision.</param>
	void OnTriggerEnter2D(Collider2D other)
	{
		Destroy(other.gameObject);
	}
}
