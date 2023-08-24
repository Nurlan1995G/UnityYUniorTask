using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private bool _isSword = false;

    public void SetActiveSword(PlayerAnimationController animationController)
    {
        

        gameObject.SetActive(false);
        _isSword = true;

         animationController.EnableSwordAnimation(_isSword);
    }
}
