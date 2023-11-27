using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    
    
    private void OnMouseDown()
    {
        if (GameManager.Instance.canDrag)
        {
            CheckAndMove();
        }
    }

    void CheckAndMove()
    {
        var x = GameManager.Instance.GetCurLevel().listSlot.Find(l => l.currentSelect == gameObject.name);
        if (x == null)
        {
            var slot = GameManager.Instance.GetCurLevel().listSlot.Find(l => l.currentSelect == "");
            if (slot != null)
            {
                GameManager.Instance.canDrag = false;
                var target = slot;
                Move(target.transform);
            }
        }
        else
        {
            GameManager.Instance.canDrag = false;
            var target = x;
            Move(target.transform);
        }
    }
    
    public void Move(Transform target)
    {
        StartCoroutine(MoveToTarget(target));
    }

    IEnumerator MoveToTarget(Transform target)
    {
        var dis = Vector3.Distance(target.position , transform.position);
        var dir = target.position - transform.position;
        while (dis > 0.1f)
        {
            yield return new WaitForEndOfFrame();
            transform.position = transform.position + dir * 0.01f;
            dis = Vector3.Distance(target.position , transform.position);
        }

        transform.position = target.position;
        target.GetComponent<Slot>().AddCar(this);
        CheckOnMoveDone();
    }

    void CheckOnMoveDone()
    {
        GameManager.Instance.EnableDrag();
    }
}
