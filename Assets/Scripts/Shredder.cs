using UnityEngine;

public class Shredder : MonoBehaviour {

    /// <summary>
    /// Destroys out of play objects
    /// </summary>
    /// <param name="other">The other object involved in the collision</param>
    private void OnTriggerExit(Collider other)
    {
        GameObject thingLeft = other.gameObject;

        if (thingLeft.GetComponent<Pin>())
        {
            Destroy(thingLeft);
        }
    }
}
