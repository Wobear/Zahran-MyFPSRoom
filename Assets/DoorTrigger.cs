using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public LayerMask LayerMask;

    protected bool _opened = false;

    protected Collider _collider;

    public Animator DoorAnimation;
    
    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<Collider>();
    }

    void OnTriggerStay(Collider col)
    {
        if (!((LayerMask.value & (1 << col.gameObject.layer)) > 0))
            return;

        if (_opened)
            return;
        
        if (DoorAnimation == null)
            return;

        DoorAnimation.SetTrigger("OpenDoor");

        _opened = true;
    }

}
