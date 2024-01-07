using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackable
{
    public delegate void RecieveAttackDele(int _hp);
    
    public int Attack();
    public void RecieveAttack(int _damage);
}