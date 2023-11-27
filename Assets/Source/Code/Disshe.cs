using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disshe : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (GameManager.Instance.canDrag)
        {
            GameManager.Instance.CheckOnDishe();
        }
    }
}
