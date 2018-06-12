using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Ball;

public class GarbageCollector : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<HybridChaser>() != null || other.gameObject.GetComponent<Chaser>() != null)
        {
            Destroy(other.gameObject);
            GameManager.DecrementBallCountText();
        }
        else if (other.gameObject.GetComponent<Ball>() != null)
        {
            other.gameObject.transform.position = new Vector3(15, 0, 15);
        }
    }
}
