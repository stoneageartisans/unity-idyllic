using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    Text compass;

	void Start()
    {
        compass = gameObject.GetComponent(typeof(Text)) as Text;

        setDirection(Camera.main.transform.localRotation.eulerAngles.y);
	}

    void Update()
    {
        setDirection(Camera.main.transform.localRotation.eulerAngles.y);
    }
    
    void setDirection(float angle)
    {
        if(angle == 337.5f || (angle > 337.5f && angle < 360.0f) || angle < 22.5f)
        {
            compass.text = "N";
        }
        else if(angle == 22.5f || (angle > 22.5f && angle < 67.5f))
        {
            compass.text = "NE";
        }
        else if(angle == 67.5f || (angle > 67.5f && angle < 112.5f))
        {
            compass.text = "E";
        }
        else if(angle == 112.5f || (angle > 112.5f && angle < 157.5f))
        {
            compass.text = "SE";
        }
        else if(angle == 157.5f || (angle > 157.5f && angle < 202.5f))
        {
            compass.text = "S";
        }
        else if(angle == 202.5f || (angle > 202.5f && angle < 247.5f))
        {
            compass.text = "SW";
        }
        else if(angle == 247.5f || (angle > 247.5f && angle < 292.5f))
        {
            compass.text = "W";
        }
        else if(angle == 292.5f || (angle > 292.5f && angle < 337.5f))
        {
            compass.text = "NW";
        }
        else
        {
            compass.text = "?";
            Debug.Log("Direcion ?: " + angle);
        }
    }
}
