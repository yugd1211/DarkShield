using UnityEngine;
public class AInteractableObeject : MonoBehaviour, IInteractable
{
	
	public void Interact(InteractableTmpPlayer player)
	{
		print("Interact");
		// Player Interact Animation Invoke
	}

	public virtual bool CanInteract()
	{
		return true;
	}
}
