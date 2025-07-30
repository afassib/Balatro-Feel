using System.Collections;
using UnityEngine;


public class ScoreGA : GameAction
{
    private IEnumerator DrawCardReactionPRE()
    {
        Debug.Log("PRE Draw!");
        yield return null;
    }

    private IEnumerator DrawCardReactionPOST()
    {
        Debug.Log("POST Draw!");
        yield return null;
    }
}