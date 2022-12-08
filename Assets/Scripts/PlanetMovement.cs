using UnityEngine;

public class PlanetMovement : MonoBehaviour
{

    public float G = 6.67f * Mathf.Pow(10, -11);

    public GameObject focusObject;
    private Vector3 focusObjectPos;

    public GameObject planet;
    private Vector3 planetPos;

    public Rigidbody planetRB;

    public float planetMass;
    public float sunMass;

    public Vector3 initVelocity = new Vector3(0f, 5f, 0f);

    void Start()
    {
        // Initial movement
        planetRB.AddForce(initVelocity, ForceMode.VelocityChange);
    }

    void FixedUpdate()
    {
        Debug.Log("Changing force, new Force: " + calculateForce());
        planetRB.AddForce(calculateForce(), ForceMode.Impulse);
    }

    public Vector3 calculateForce()
    {
        // Find positions of the objects
        focusObjectPos = focusObject.transform.position;
        planetPos = planet.transform.position;


        // Distance between objects ( magnitude)
        float distance = Vector3.Distance(focusObjectPos, planetPos);

        // Distance Squared
        float distanceSquared = distance * distance;

        // force maginitude
        float force = G * sunMass * planetMass / distanceSquared;

        // Force with Direction calculation
        Vector3 heading = (focusObjectPos - planetPos);

        Vector3 forceVector = (force * (heading/heading.magnitude));

        Debug.Log("Distance : " + distance + ", force: " + force + ", Forcevector: " + forceVector + "(" + (focusObjectPos - planetPos) + ")");
        return forceVector;
    }
}
