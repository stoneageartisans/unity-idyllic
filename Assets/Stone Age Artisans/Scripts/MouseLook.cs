using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Range(25.0f, 250.0f)]
    public float sensitivity = 100.0f;

    float rotationX; // horizontal movement
    float rotationY; // vertical movement

	void Start()
    {
        rotationX = transform.localRotation.eulerAngles.x;
        rotationY = transform.localRotation.eulerAngles.y;
	}
	
	void Update()
    {
        // Get the change
        rotationY += (Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime);
        rotationX += (-Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime);

        // Apply it
        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0.0f);
	}
}
