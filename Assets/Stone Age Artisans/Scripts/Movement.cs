using UnityEngine;

public class Movement : MonoBehaviour
{
    [Range(1.0f, 100.0f)]
    public float speed = 100.0f;

	void Start()
    {
		// TODO
	}
	
	void Update()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed * Time.deltaTime;
	}
}
