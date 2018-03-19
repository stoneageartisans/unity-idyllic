using System;
using UnityEngine;

public class GameTime : MonoBehaviour
{
    public static GameTime instance;

    [HideInInspector]
    public DateTime dateTime;

    [Tooltip("The speed multiplier for how fast time passes in-game")]
    public float speed = 10.0f;

    [Range(1, 9999)]
    public int year = 1;

    [Range(1, 12)]
    public int month = 1;

    [Range(1, 31)]
    public int day = 1;

    [Range(0, 23)]
    public int hour = 6;

    [Range(0, 59)]
    public int minute = 0;

    [Range(0, 59)]
    public int second = 0;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("ERROR: An instance of " + gameObject.name + " already exists.");
            Destroy(gameObject);
        }
    }

	void Start()
    {
        if(day > DateTime.DaysInMonth(year, month))
        {
            day = DateTime.DaysInMonth(year, month);
        }

        dateTime = new DateTime(year, month, day, hour, minute, second);
	}
	
	void Update()
    {
        dateTime = dateTime.AddSeconds(Time.deltaTime * speed);
	}
}
