using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum QueueState { empty, wait, full }
public class AtkQueue : MonoBehaviour
{
  
    public Queue<LivingEntity> atkQueue=new Queue<LivingEntity>();
    public QueueState state = QueueState.empty;
    public int maxSize;
    public void add2Queue(LivingEntity entity)
    {
        switch (state)
        {
            case QueueState.empty:
                state = QueueState.wait; //ignore 1 paramenter
                break;
            case  QueueState.wait:
                addQueue(entity);
                break;
            case QueueState.full:
                Debug.Log("Full Queue Need Handler");
                break;
        }
    }
    public void addQueue(LivingEntity entity)
    {
        atkQueue.Enqueue(entity);
        if (atkQueue.Count == maxSize) state = QueueState.full;
        else
            state = QueueState.wait;
    }
  
    public void clearQueue()
    {
        atkQueue.Clear();
    }
}
