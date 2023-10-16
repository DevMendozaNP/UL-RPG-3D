using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition
{
    public System.Func<bool> IsValid {private set; get;}

    public System.Func<State> GetNextState {private set; get;}

    public Transition(
        System.Func<bool> isValid,
        System.Func<State> getNextState
    ){
        IsValid = isValid;
        GetNextState = getNextState;
    }
}
