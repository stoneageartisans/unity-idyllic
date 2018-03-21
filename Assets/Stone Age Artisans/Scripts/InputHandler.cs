using UnityEngine;

public class InputHandler : MonoBehaviour
{
	void Start()
    {
		// TODO
	}
	
	void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(Time.timeScale == 0.0f)
            {
                Time.timeScale = 1.0f;
            }
            else
            {
                Time.timeScale = 0.0f;
            }
        }
	}
}
