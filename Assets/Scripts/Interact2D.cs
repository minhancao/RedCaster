using UnityEngine;
using UnityEngine.Events;

//Based on InterractOnTrigger2D with InterractOnButton2D from Gamekit2D

[RequireComponent(typeof(Collider2D))]
public class Interact2D : MonoBehaviour
{
    public LayerMask layers;
    public UnityEvent OnEnter, OnExit;
    // public InventoryController.InventoryChecker[] inventoryChecks;

    protected Collider2D m_Collider;

    public UnityEvent OnButtonPress;

    bool m_CanExecuteButtons;

    void Reset() 
    {
        layers = LayerMask.NameToLayer("Everything");
        m_Collider = GetComponent<Collider2D>();
        m_Collider.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!enabled)
            return;
        ExecuteOnEnter(other);

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!enabled)
            return;
        ExecuteOnExit(other);
    }

    void ExecuteOnEnter(Collider2D other)
    {
        m_CanExecuteButtons = true;
        OnEnter.Invoke ();
    }

    void ExecuteOnExit(Collider2D other)
    {
        m_CanExecuteButtons = false;
        OnExit.Invoke ();
    }

    void Update()
    {
        if (m_CanExecuteButtons)
        {
            if (OnButtonPress.GetPersistentEventCount() > 0 && Input.GetKeyUp(Controls.player.interact))
                OnButtonPress.Invoke();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "InteractionTrigger", false);
    }
}