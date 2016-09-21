using UnityEngine;
using System.Collections;
using JetBrains.Annotations;

public interface GameMode
{

    void RightMouseClicked();
    void LeftMouseClicked();
    void Update();
    void Exit();

}
