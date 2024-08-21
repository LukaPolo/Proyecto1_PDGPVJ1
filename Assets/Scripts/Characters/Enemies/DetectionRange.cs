using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionRange : MonoBehaviour{
    [SerializeField] private LayerMask layer;
    [SerializeField] private float rangeSize;

    public bool DetectCollision(float range){
        rangeSize = range;
        Collider2D collider = Physics2D.OverlapCircle(transform.position, range, layer);
        if(collider){
            return true;
        }else{
            return false;
        }
    }

    private void OnDrawGizmos(){
        Gizmos.DrawWireSphere(transform.position, rangeSize);
    }
}