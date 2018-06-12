using UnityEngine;
using Unity.Entities;

public class Rotator : MonoBehaviour {

    public float speed = 10;

    private void Update()
    {

        transform.Rotate(0f, speed * Time.deltaTime, 0f);
    }

}