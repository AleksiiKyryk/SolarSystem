using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestrialBody : MonoBehaviour
{

    public float surfaceGravity;
    public float mass { get; private set; }
    public float radius;
    public Vector3 initialVelocity;
    public Vector3 currentVelocity { get; private set; }
    Rigidbody rb;
    Transform meshHolder;
    public string bodyName = "Unnamed";

    void Awake()
    {
        
        rb = GetComponent<Rigidbody>();
        rb.mass = mass;
        currentVelocity = initialVelocity;
    }

    void OnValidate()
    {
        mass = surfaceGravity * radius * radius / Universe.gravitationalConstant;
        meshHolder = transform.GetChild(0);
        meshHolder.localScale = Vector3.one * radius;
        gameObject.name = bodyName;
    }

    public void UpdateVelocity(CelestrialBody[] allBodies, float timeStep)
    {
        // repeat for every body
        foreach (var otherBody in allBodies)
        {
            // check that the body isnt updating velocity relatively to itself
            if (otherBody != this)
            {
                float sqrDistance = (otherBody.rb.position - rb.position).sqrMagnitude;
                Vector3 forceDirection = (otherBody.rb.position - rb.position).normalized;
                Vector3 force = forceDirection * Universe.gravitationalConstant * mass * otherBody.mass / sqrDistance;
                Vector3 acceleration = force / mass;
                currentVelocity += acceleration * timeStep;
            }
        }
    }

    public void UpdatePosition(float timeStep)
    {
        rb.position += currentVelocity * timeStep;
    }

}
