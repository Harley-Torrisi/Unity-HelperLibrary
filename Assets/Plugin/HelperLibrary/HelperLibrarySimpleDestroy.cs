using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDestroy : MonoBehaviour
{
    [SerializeField] private GameObject target;

    [SerializeField] private float waitTime = 0;

    private void Start() => Destroy(target, waitTime);

    private void Reset() => target = this.gameObject;
}
