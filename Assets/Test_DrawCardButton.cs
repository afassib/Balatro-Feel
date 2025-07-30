using System.Collections;
using UnityEngine;

public class Test_DrawCardButton : MonoBehaviour
{
    ActionSystem _actionSystem;
    public HorizontalCardHolder from;
    public HorizontalCardHolder to;
    public int index;
    public void PerformDraw()
    {
        Debug.Log("Start buttton : ");
        if (ActionSystem.Instance.IsPerforming) return;
        DrawCardGA drawCardGA = new DrawCardGA();
        ActionSystem.Instance.Perform(drawCardGA);
    }

    private void OnEnable()
    {
        ActionSystem.AttachPerformer<DrawCardGA>(DrawCardPerformer);
        ActionSystem.SubscribeReaction<DrawCardGA>(DrawCardReactionPRE, ReactionTiming.PRE);
        ActionSystem.SubscribeReaction<DrawCardGA>(DrawCardReactionPOST, ReactionTiming.POST);
    }

    private void OnDisable()
    {
        ActionSystem.DetachPerformer<DrawCardGA>();
        ActionSystem.UnsubscribeReaction<DrawCardGA>(DrawCardReactionPRE, ReactionTiming.PRE);
        ActionSystem.UnsubscribeReaction<DrawCardGA>(DrawCardReactionPOST, ReactionTiming.POST);
    }

    private void Awake()
    {
        _actionSystem = ActionSystem.Instance;
    }


    // performers

    private IEnumerator DrawCardPerformer(DrawCardGA drawCardGA)
    {
        Debug.Log("Draw Card!");
        yield return null;
    }

    private void DrawCardReactionPRE(DrawCardGA drawCardGA)
    {
        Debug.Log("PRE Draw!");
    }

    private void DrawCardReactionPOST(DrawCardGA drawCardGA)
    {
        Debug.Log("POST Draw!");
    }

    public void MoveCard()
    {
        to.MoveCard(from, index);
    }
}
