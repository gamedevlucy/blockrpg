using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BasicCharacter : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
    GameObject healthbarObject = transform.Find("HealthbarContainer").gameObject;
    healthbar characterHealthbar = healthbarObject.GetComponent<healthbar>();
    characterHealthbar.UpdateForNewStats(gameObject);
    
  }

  // Update is called once per frame
  void Update()
  {
  }

  void OnClick(ClickEvent e)
  {
    // 0 is left mouse
    // 1 is right mouse
    // 2 is middle mouse
    switch(e.button)
    {
      case 0:
        // highlight in initiative order / stat block
        // maybe a little animation
        break;
      default:
        break;
    }
  }

  public void OnAttacked(BasicCharacter attacker, int damage)
  {
    Stats selfStats = GetComponent<Stats>();
    int effectiveAttack = damage - selfStats.mDefense;
    if(effectiveAttack > 0)
    {
      selfStats.mDamage += effectiveAttack;
      if(selfStats.mDamage < selfStats.mHealth)
      {
        Die();
      }
      else
      {
        Knockback();
      }
    }
    else
    {
      attacker.Knockback();
    }

  }

  public void Knockback()
  {
    // todo put a little anim here
  }

  public void Attack(BasicCharacter defender)
  {
    if(defender == null)
    {
      return;
    }
    Stats selfStats = GetComponent<Stats>();
    if(selfStats == null)
    {
      return;
    }
    defender.OnAttacked(this, selfStats.mAttack);

  }

  public void Die()
  {
  }
}
