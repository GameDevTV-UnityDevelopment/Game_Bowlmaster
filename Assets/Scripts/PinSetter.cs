using UnityEngine;

public class PinSetter : MonoBehaviour
{
    public GameObject pinSet;

    private Animator animator;
    private PinCounter pinCounter;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        pinCounter = GameObject.FindObjectOfType<PinCounter>();
    }

    /// <summary>
    /// Raises pins
    /// </summary>
    public void RaisePins()
    {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.RaiseIfStanding();
        }
    }

    /// <summary>
    /// Lowers pins
    /// </summary>
    public void LowerPins()
    {
        // raise standing pings only by distanceToRaise
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.Lower();
        }
    }

    /// <summary>
    /// Renews pins
    /// </summary>
    public void RenewPins()
    {
        GameObject newPins = Instantiate(pinSet);
        newPins.transform.position = new Vector3(0, 25, 1829);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="action"></param>
    public void PerformAction(ActionMaster.Action action)
    {
        if (action == ActionMaster.Action.Tidy)
        {
            animator.SetTrigger("tidyTrigger");
        }
        else if (action == ActionMaster.Action.EndTurn)
        {
            pinCounter.Reset();
            animator.SetTrigger("resetTrigger");
        }
        else if (action == ActionMaster.Action.Reset)
        {
            pinCounter.Reset();
            animator.SetTrigger("resetTrigger");
        }
        else if (action == ActionMaster.Action.EndGame)
        {
            throw new UnityException("Don't know how to end game yet");
        }
    }
}
