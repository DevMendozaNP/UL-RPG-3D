using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public abstract void OnStart();
    public abstract void OnUpdate();
    public abstract void OnFinish();
}
