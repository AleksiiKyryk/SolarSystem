using UnityEngine;

public class CameraController : MonoBehaviour
{


    public Transform CelestrialBody;
    public Vector3 offset;
    public float currentZoom = 1f;
    public float minZoom = 0.5f;
    public float maxZoom = 5f;
    public float zoomSpeed = 1f;

    public float yawSpeed = 100f;	// How quickly we rotate
    public float currentYaw = 0f;

    // Update is called once per frame
    void Update()
    {
        // Adjust our zoom based on the scrollwheel
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;

    }

    private void LateUpdate()
    {
        //Vector3 temp = CelestrialBody.position + offset;
        //temp.x = temp.x * currentZoom;
        //temp.z = temp.z * currentZoom;

       

        transform.position = CelestrialBody.position - offset * currentZoom;
        transform.LookAt(CelestrialBody.position + Vector3.up);
        transform.RotateAround(CelestrialBody.position, Vector3.up, currentYaw);
    }






}
