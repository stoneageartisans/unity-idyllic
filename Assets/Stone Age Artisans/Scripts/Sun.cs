using System;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public static Sun instance;

    new Light light;

    Material sky;

    float[,] atmosphereThickness = new float[24, 60];
    Color[,] skyTint = new Color[24, 60];
    Vector3[,,] lightDirection = new Vector3[24, 60, 60];

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

	void Start()
    {
        light = gameObject.GetComponent(typeof(Light)) as Light;
        sky = (Camera.main.gameObject.GetComponent(typeof(Skybox)) as Skybox).material;

        float redIncrement = 0.01f;
        float blueIncrement = 0.01f;
        float currentRed = 0.5f;
        float currentBlue = 0.5f;

        float thicknessModifier = 1.002f;
        float currentThickness = 1.0f / thicknessModifier;

        float rotationIncrement = (365.0f / 24.0f / 60.0f / 60.0f);
        float currentRotationX = 270.0f - rotationIncrement;

        for(int hour = 0; hour < 24; hour ++)
        {
            for(int minute = 0; minute < 60; minute ++)
            {
                // From 4:45 to 5:14 OR 17:45 to 18:14
                if(((hour == 4 || hour == 17) && minute > 44) || ((hour == 5 || hour == 18) && minute < 15))
                {
                    if(currentRed > 0.20f)
                    {
                        currentRed -= redIncrement;
                    }

                    if(currentBlue > 0.20f)
                    {
                        currentBlue -= blueIncrement;
                    }
                }
                // From 5:15 to 5:44 OR 18:15 to 18:44
                else if((hour == 5 || hour == 18) && (minute > 14 && minute < 45))
                {
                    if(currentRed < 0.5f)
                    {
                        currentRed += redIncrement;
                    }

                    if(currentBlue < 0.5f)
                    {
                        currentBlue += blueIncrement;
                    }
                }
                else
                {
                    currentRed = 0.5f;
                    currentBlue = 0.5f;
                }

                skyTint[hour, minute] = new Color(currentRed, 0.5f, currentBlue);

                // At 00:00 AND 12:00
                if((hour == 0 && minute == 0) || (hour == 12 && minute == 0))
                {                    
                    currentThickness = 1.0f / thicknessModifier;
                }

                // From 00:00 AM to 6:00 OR 12:00 to 18:00
                if((hour >= 0 && hour < 6) || (hour >= 12 && hour < 18))
                {
                    currentThickness *= thicknessModifier;
                }
                else
                {                    
                    currentThickness /= thicknessModifier;
                }

                atmosphereThickness[hour, minute] = currentThickness;

                for(int second = 0; second < 60; second++)
                {
                    currentRotationX += rotationIncrement;

                    if(currentRotationX >= 360.0f)
                    {
                        currentRotationX = 0.0f;
                    }

                    lightDirection[hour, minute, second] = new Vector3(currentRotationX, -90.0f, 0.0f);
                }
            }
        }

        setLightDirection();
        setAtmosphereThickness();
        setSkyTint();
	}

    void Update()
    {
        setLightDirection();
        setAtmosphereThickness();
        setSkyTint();
    }

    void setAtmosphereThickness()
    {
        sky.SetFloat("_AtmosphereThickness", atmosphereThickness[GameTime.instance.dateTime.Hour, GameTime.instance.dateTime.Minute]);
    }

    void setLightDirection()
    {
        light.transform.eulerAngles = lightDirection[GameTime.instance.dateTime.Hour, GameTime.instance.dateTime.Minute, GameTime.instance.dateTime.Second];
    }

    void setSkyTint()
    {
        sky.SetColor("_SkyTint", skyTint[GameTime.instance.dateTime.Hour, GameTime.instance.dateTime.Minute]);
    }
}
