using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private Transform _portal;
    
    public void TransitionTP(PlayerPortal pLayer)
    {
        Debug.Log("TransitionTP сработал");

        pLayer.transform.position = new Vector3(_portal.position.x, _portal.position.y, pLayer.transform.position.z);
    }
}
