using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BasicCharacter : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
    
  }

  // Update is called once per frame
  void Update()
  {
    if(Input.GetKeyUp(KeyCode.A))
    {
      Stats stats = GetComponent<Stats>();
      stats.Die();
    }
  }
}
