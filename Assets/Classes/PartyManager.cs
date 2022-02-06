using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyManager : MonoBehaviour
{
  ArrayList mPartyMembers = new ArrayList();
  GameObject[][] mPartyGrid;
  public int MaxPositions;
  public int MaxRows;

  // Start is called before the first frame update
  void Start()
  {
    
  }

  // Update is called once per frame
  void Update()
  {
    
  }

  GameObject GetCharacterInPosition(int position, int row)
  {
    return mPartyGrid[position][row];
  }

  bool SetCharacterInPosition(GameObject character, int position, int row)
  {
    if(mPartyGrid[position][row] != null)
    {
      return false;
    }
    mPartyGrid[position][row] = character;
    return true;
  }


  void ArrangeParty()
  {
    for(int position = 0; position < MaxPositions; position++)
    {
      for(int row = 0; row < MaxRows; row++)
      {
        mPartyGrid[position][row] = null;
      }
    }

    foreach(var member in mPartyMembers)
    {
      GameObject partyMember = member as GameObject;
      if(partyMember == null)
      {
        continue;
      }

      



    }
  }

  void AddPartyMember(GameObject newPartyMember)
  {
    mPartyMembers.Add(newPartyMember);
  }
}
