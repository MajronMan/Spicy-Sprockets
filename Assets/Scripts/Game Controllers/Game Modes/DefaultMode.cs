using UnityEngine;
using System.Collections;

public class DefaultMode : GameMode
{
    private int i = 0;

    public void RightMouseClicked()
    {
        Debug.Log("Right" + i);
        i++;

    }

    public void LeftMouseClicked()
    {
        Debug.Log("Left" + i);
        i++;
    }

    public void Update()
    {
        
    }

    public void Exit()
    {
        
    }

    public void Select(GameObject gameObject)
    {
        
    }
}
