using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public bool IsSword {get; private set;}

    public void SetActiveSword()
    {
        gameObject.SetActive(false);
        IsSword = true;
    }
}
