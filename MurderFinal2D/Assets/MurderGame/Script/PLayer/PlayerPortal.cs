using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPortal : MonoBehaviour
{
    private bool _isTransition = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Portal portal)) 
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
