using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Range(25.0f, 250.0f)]
    public float sensitivity = 100.0f;
    //public float clampAngle = 80.0f;

    private float rotationY = 0.0f; // rotation around the up/y axis
    private float rotationX = 0.0f; // rotation around the right/x axis

	void Start()
    {
        Vector3 rotation = transform.localRotation.eulerAngles;
        rotationY = rotation.y;
        rotationX = rotation.x;
	}
	
	void Update()
    {
        rotationY += (Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime);
        rotationX += (-Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime);

        //rotationX = Mathf.Clamp(rotationX, -clampAngle, clampAngle);

        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0.0f);
	}
}
