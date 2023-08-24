using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPortal : Player
{
    private bool _isTransition = true;

    public void PlayPortal(Collider2D collision)
    {
        TransitionPortal(collision);
    }

    public void StopPortal(Collider2D collision)
    {

    }

    public void TransitionPortal(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Portal portal))
        {
            if (_isTransition)
            {
                _isTransition = false;
                portal.gameObject.GetComponent<Portal>().TransitionTP(this);
                StartCoroutine(WaitTransition());
            }
        }
    }

    private IEnumerator WaitTransition()
    {
        yield return new WaitForSeconds(3f);

        _isTransition = true;
    }
}
