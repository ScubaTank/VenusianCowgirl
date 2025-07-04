using UnityEngine;

public class InteractBox : MonoBehaviour, IInteractable
{

    public void Interact()
    {
        //do something when interacted
        Debug.Log("Interacted!");
    }
}
