	using System.Linq;
using UnityEngine;
using Context = UnityEngine.InputSystem.InputAction.CallbackContext;
public class InteractableTmpPlayer : MonoBehaviour
{
	public float detectionRadius = 2f;
	// InteractableObject를 감지하는 역할도 임시로 부여
	// 해당 객체를 그냥 따로 두는 것도 좋을듯함
	
	public void OnInteract(Context context)
	{
		if (!context.performed)
			return;
		Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius);
		IInteractable interactableObject = null;
		Collider detectedInteractableCollider = colliders.ToList().Find(collider => collider.TryGetComponent(out interactableObject));
		if (!detectedInteractableCollider)
			return;
		if (interactableObject.CanInteract())
			interactableObject.Interact(this);
	}
}
