using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AttackAnim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShakeEffect(GameObject target, float duration)
    {
        target.transform.DOShakePosition(duration, new Vector3(0.05f, 0.05f, 0), 10, 90, false, true).OnComplete(() => 
        {
            Debug.Log("Animasi Selesai");
        });
    }
}
