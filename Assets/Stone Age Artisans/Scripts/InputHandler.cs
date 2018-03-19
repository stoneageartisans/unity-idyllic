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
	}
}
