using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField]float speed;
    private void Update()
    {
        float dis = Vector2.Distance(transform.position, target.position);
        if (dis > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
            Debug.Log("distance" + dis);
        }
    }
}
