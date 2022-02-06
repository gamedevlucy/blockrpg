using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Stats : MonoBehaviour
{
  public int m_Attack;
  public int m_Defense;
  public int m_Health;

  int m_Damage;

  int m_Row;
  int m_Position;

  public bool IsAlive()
  {
    return (m_Health - m_Damage) > 0;
  }

  public void Attack(int totalDamage)
  {
    int effectiveDamage = totalDamage - m_Defense;
    m_Health -= effectiveDamage;

    if(!IsAlive())
    {
      Die();
    }
  }

  public void Die()
  {
    SpriteRenderer sprite = GetComponent<SpriteRenderer>();
    sprite.transform.Rotate(0.0f, 0.0f, 90.0f);
  }


  // Update is called once per frame
  void Update()
  {
      
  }
}
