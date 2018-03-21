using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    Text clock;

	void Start()
    {
        clock = gameObject.GetComponent(typeof(Text)) as Text;

        clock.text = string.Format("{0:D2}:{1:D2}:{2:D2}", GameTime.instance.dateTime.Hour, GameTime.instance.dateTime.Minute, GameTime.instance.dateTime.Second);
	}
	
	void Update()
    {
        clock.text = string.Format("{0:D2}:{1:D2}:{2:D2}", GameTime.instance.dateTime.Hour, GameTime.instance.dateTime.Minute, GameTime.instance.dateTime.Second);
	}
}
