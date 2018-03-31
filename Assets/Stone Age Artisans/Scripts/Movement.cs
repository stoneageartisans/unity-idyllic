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
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0.0f, Input.GetAxis("Vertical") * speed * Time.deltaTime) ;
	}
}
