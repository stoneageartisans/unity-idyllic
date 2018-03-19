using System;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public static Sun instance;

    new Light light;

    Material sky;

    float[,] atmosphereThickness = new float[24, 60];

    float[,,] sunX = new float[24, 60, 60];
    float sunY = -90.0f;
    float sunZ= 0.0f;

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
        sky = (Camera.main.gameObject.GetComponent(typeof(Skybox)) as Skybox).material;

        light = gameObject.GetComponent(typeof(Light)) as Light;

        float currentThickness = 0.998004f;
        float thicknessModifier = 1.002f;
        float rotationIncrement = (365.0f / 24.0f / 60.0f / 60.0f);
        float currentRotation = 270.0f - rotationIncrement;

        for(int hour = 0; hour < 24; hour ++)
        {
            for(int minute = 0; minute < 60; minute ++)
            {
                if((hour == 0 && minute == 0) || (hour == 12 && minute == 0))
                {
                    currentThickness = 0.998004f;
                }

                // From 00:00 AM to 6:00 OR from 12:00 to 18:00
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
                    currentRotation += rotationIncrement;

                    if(currentRotation >= 360.0f)
                    {
                        currentRotation = 0.0f;
                    }

                    sunX[hour, minute, second] = currentRotation;
                }
            }
        }

        setPosition();
        setAtmosphereThickness();
	}

    void Update()
    {
        setPosition();
        setAtmosphereThickness();
    }

    void setAtmosphereThickness()
    {
        sky.SetFloat("_AtmosphereThickness", atmosphereThickness[GameTime.instance.dateTime.Hour, GameTime.instance.dateTime.Minute]);
    }

    void setPosition()
    {
        light.transform.eulerAngles = new Vector3(
            sunX[GameTime.instance.dateTime.Hour, GameTime.instance.dateTime.Minute, GameTime.instance.dateTime.Second],
            sunY,
            sunZ
        );
    }
}
