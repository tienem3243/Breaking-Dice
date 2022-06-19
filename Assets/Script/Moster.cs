using UnityEngine;

public class Moster : MonoBehaviour,Monster
{
    [SerializeField]int hp;
    [SerializeField] int dame;
    [SerializeField] string name;
    public void TakeDame(int dame)
    {
        hp -= dame;
        
    }
   public void setHp(int hp)
    {
        this.hp = hp;
    }
    public int getHp()
    {
        return hp;
    }
    public void setDame(int dame)
    {
        this.dame = dame;
    }
    public int getDame()
    {
        return dame;
    }

    public void hitBy(Warrior warrior,int dame)
    {
        int realDame = dame;
        TakeDame(realDame);
        Debug.Log(name+ " take " + realDame + " from "+warrior.name);
    }
    
    public void hitBy(Wizard wizard,int dame)
    {
        int realDame = dame* 2;
        TakeDame(realDame);
        Debug.Log(name+ " take " + realDame+ " from "+wizard.name);
    }
}
