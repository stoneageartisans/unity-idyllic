using UnityEngine;

public class CloudLayer : MonoBehaviour
{
    [Range(-25.0f, 25.0f)]
    public float speedX = 0.0f;

    [Range(-25.0f, 25.0f)]
    public float speedY = 0.0f;

    float offsetX;
    float offsetY;

    Material material;

	void Start()
    {
        if(speedX == 0.0f)
        {
            offsetX = speedX;
        }
        else
        {
            offsetX = speedX / 500.0f;
        }

        if(speedY == 0.0f)
        {
            offsetY = speedY;
        }
        else
        {
            offsetY = speedY / 500.0f;
        }

        material = (GetComponent(typeof(Renderer)) as Renderer).material;
	}
	
	void Update()
    {
        transform.position = Camera.main.transform.position;

        material.mainTextureOffset = new Vector2(Time.time * offsetX, Time.time * offsetY);
	}
}
