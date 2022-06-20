using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum QueueState {wait, full,close}
public class AtkQueue : MonoBehaviour
{
  
    public Queue<LivingEntity> atkQueue=new Queue<LivingEntity>();
    public QueueState state = QueueState.close;
    public int maxSize;
    public Skill skill;
    public LivingEntity owner;
    public void add2Queue(LivingEntity entity)
    {
        if(state!=QueueState.close)
        switch (state)
        {
                case QueueState.wait:
                addQueue(entity);
                break;
                case QueueState.full:
                Debug.Log("Full Queue Need Handler");
                break;
        }
        else
        {
            Debug.Log("Queue is not registed beforce use");
        }
    }
    public void QueueRegister(Skill skill,LivingEntity owner)
    {
        clearQueue();
        this.skill = skill;
        this.owner = owner;
        maxSize = skill.TargetCount;
        state = QueueState.wait;
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
        state = QueueState.close;
        atkQueue.Clear();
        skill = null;
        owner = null;
        maxSize = 0;
      
    }
    /*TODO
     * pop out target
     * check if amount of target < require skill target
     * clear queue when attach to void space
     * check duplicate target
     * visual handle and limit target fit to skill 
     */
}
