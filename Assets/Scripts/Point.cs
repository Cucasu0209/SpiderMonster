using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Point : MonoBehaviour
{
    private void OnEnable()
    {
        UnHighlight();
    }
    public void Highlight()
    {
        transform.DOKill();
        transform.DOScale(0.12f, 0.1f);
    }
    public void UnHighlight()
    {
        transform.DOKill();
        transform.DOScale(0.05f, 0.1f);
    }

}
