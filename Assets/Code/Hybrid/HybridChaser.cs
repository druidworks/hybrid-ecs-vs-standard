using UnityEngine;
using Unity.Entities;

public class HybridChaser : MonoBehaviour {
    public float speed = 1f;
    public float maxSpeed = 50f;
}

class ChaseSystem : ComponentSystem
{
    struct Component
    {
        public Transform transform;
        public Rigidbody rigidbody;
        public HybridChaser chase;
    }

    protected override void OnUpdate()
    {
        var time = Time.deltaTime;
        GameObject playerInstance = GameManager.GetPlayerInstance();

        ComponentGroupArray<Component> components = GetEntities<Component>();

        foreach (var e in components)
        {
            e.rigidbody.maxAngularVelocity = e.chase.maxSpeed / 2;
            Move(playerInstance, e);
        }
    }

    private void Move(GameObject playerInstance, Component e)
    {
        Vector3 moveDirection = (playerInstance.transform.position - e.transform.position).normalized;
        e.rigidbody.AddTorque(new Vector3(moveDirection.z, 0, -moveDirection.x) * e.chase.speed);
    }
}