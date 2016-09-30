using UnityEngine;
using System.Collections;
using JetBrains.Annotations;

public interface GameMode
{

    void RightMouseClicked();
    void LeftMouseClicked();
    // This is NOT a built-in method, you need to call it in MonoBehaviour's update to work
    void Update();
    void Exit();
    void Select(GameObject gameObject);

}
