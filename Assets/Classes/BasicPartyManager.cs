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

    const float spacing = 0.4f;

    SpriteRenderer[] sprites = new SpriteRenderer[mPartyMembers.Count];

    int partyIndex = 0;
    foreach(GameObject partyMember in mPartyMembers)
    {
      GameObject characterSprite = partyMember.transform.Find("CharacterSprite").gameObject;
      sprites[partyIndex] = characterSprite.GetComponent<SpriteRenderer>();
      ++partyIndex;
    }



    float totalPartyHeight = 0.0f;
    for(partyIndex = 0; partyIndex < (mPartyMembers.Count - 1); ++partyIndex)
    {
      totalPartyHeight += sprites[partyIndex].bounds.size.y + spacing;
    }
    totalPartyHeight += sprites[partyIndex].bounds.size.y;


    Vector3 startPosition = getRootPosition();
    startPosition.y = totalPartyHeight * 0.5f;
    partyIndex = 0;
    foreach(GameObject partyMember in mPartyMembers)
    {
      float halfHeight = sprites[partyIndex].bounds.size.y * 0.5f;
      startPosition.y -= halfHeight;
      partyMember.transform.position = startPosition;
      startPosition.y -= (halfHeight + spacing);

      startPosition.x += (float)mFacingDir * spacing;

      ++partyIndex;
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
