using UnityEngine;
using Unity.Entities;

public class HybridRotator : MonoBehaviour {

    public float speed;

}

class RotatorSystem : ComponentSystem
{
    struct Components
    {
        public HybridRotator rotator;
        public Transform transform;
        public Rigidbody rigidbody;
    }

    protected override void OnUpdate()
    {
        var time = Time.deltaTime;

        foreach (var e in GetEntities<Components>())
        {
            e.transform.Rotate(0f, e.rotator.speed * time, 0f);
        }
    }
}