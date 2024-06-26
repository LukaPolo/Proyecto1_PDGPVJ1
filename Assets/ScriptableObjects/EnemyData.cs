using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Enemy Data")]
public class EnemyData : ScriptableObject{
    [SerializeField]private float detectionRange;
    [SerializeField]private float reactionTime;
    [SerializeField]private float waitTime;
    [SerializeField]private bool isAlert;

    public float DetectionRange {get {return detectionRange;} set {detectionRange = value;}}
    public float ReactionTime {get {return reactionTime;} set {reactionTime = value;}}
    public float WaitTime {get {return waitTime;} set {waitTime = value;}}
    public bool IsAlert {get {return isAlert;} set {isAlert = value;}}
}