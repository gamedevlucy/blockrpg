using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BasicPartyManager : MonoBehaviour
{
  public List<GameObject> mPartyMembers = new List<GameObject>();
  public int mFacingDir;

  

  // Start is called before the first frame update
  void Start()
  {
    arrangeParty();
  }

  // Update is called once per frame
  void Update()
  {
    
  }

  //GameObject GetCharacterInPosition(int position, int row)
  //{
  //  return mPartyGrid[position][row];
  //}

  //bool SetCharacterInPosition(GameObject character, int position, int row)
  //{
  //  if(mPartyGrid[position][row] != null)
  //  {
  //    return false;
  //  }
  //  mPartyGrid[position][row] = character;
  //  return true;
  //}


  void arrangeParty()
  {
    if(mPartyMembers.Count == 0)
    {
      return;
    }

    const float spacing = 0.0f;

    float totalPartyHeight = 0.0f;
    int partyIndex;
    for(partyIndex = 0; partyIndex < (mPartyMembers.Count - 1); ++partyIndex)
    {
      GameObject partyMember = mPartyMembers[partyIndex];
      SpriteRenderer memberSprite = partyMember.GetComponent<SpriteRenderer>();
      totalPartyHeight += (memberSprite.sprite.rect.height + spacing);
    }
    totalPartyHeight += mPartyMembers[partyIndex].GetComponent<SpriteRenderer>().sprite.rect.height;

    Vector3 startPosition = getRootPosition();
    startPosition.y = totalPartyHeight * 0.5f;
    foreach(GameObject partyMember in mPartyMembers)
    {
      SpriteRenderer memberSprite = partyMember.GetComponent<SpriteRenderer>();
      float halfHeight = memberSprite.sprite.rect.height;
      startPosition.y -= halfHeight;
      partyMember.GetComponent<Transform>().position = startPosition;
      startPosition.y -= (halfHeight + spacing);


      startPosition.x += (float)mFacingDir * spacing;
    }
  }

  public void AddPartyMember(GameObject newPartyMember)
  {
    mPartyMembers.Add(newPartyMember);
  }

  Vector3 getRootPosition()
  {
    return gameObject.GetComponent<Transform>().position;
  }
}
