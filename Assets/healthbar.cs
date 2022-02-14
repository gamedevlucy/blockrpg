using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using Unity.Mathematics;
using UnityEngine;

public class healthbar : MonoBehaviour
{
  Color[] mColorArray = new Color[] { Color.green, Color.cyan, Color.blue, Color.magenta, Color.red, Color.white};

  int intpow(int value, int power)
  {
    int baseValue = value;
    if(power < 0)
    {
      return 0;
    }

    --power;
    while(power > 0)
    {
      value *= baseValue;
      --power;
    }
    return value;
  }


  // Start is called before the first frame update
  void Start()
  {
  }

  public void UpdateForNewStats(GameObject parentObject)
  {
    Stats statsComponent = parentObject.GetComponent<Stats>();
    int healthValue = math.max(0, statsComponent.mHealth);

    int maxSegments = 10;
    int segmentValue = 1;
    int segmentCount = healthValue / segmentValue;
    int colorIndex = 0;

    while(segmentCount > maxSegments)
    {
      segmentValue *= 10;
      segmentCount = healthValue / segmentValue;
      ++colorIndex;
    }
    if(healthValue % segmentValue > 0)
    {
      ++segmentCount;
    }

    GameObject[] healthbarStructureObjects = {
      transform.Find("HealthbarOutline").gameObject,
      transform.Find("HealthbarLines").gameObject
    };

    GameObject healthbarColorObject = transform.Find("HealthbarColor").gameObject;

    float leftSide = 0.0f;
    for(int i = 0; i < healthbarStructureObjects.Length; ++i)
    {
      SpriteRenderer currentSprite = healthbarStructureObjects[i].GetComponent<SpriteRenderer>();
      currentSprite.size = new Vector2((float)segmentCount, 1.0f);
      leftSide = currentSprite.bounds.min.x;
    }

    healthbarColorObject.GetComponent<SpriteRenderer>().color = mColorArray[math.min(colorIndex, mColorArray.Length - 1)];

    float healthPercentage = (float)(healthValue - statsComponent.mDamage)/(float)healthValue;
    float resultScale = (float)segmentCount * healthPercentage * 0.2f;
    healthbarColorObject.transform.localScale = new Vector3(resultScale, .2f, 1.0f);
    Vector3 originalPos = healthbarColorObject.transform.position;
    originalPos.x = leftSide + (resultScale * 0.5f);
    healthbarColorObject.transform.position = originalPos;
  }

  // Update is called once per frame
  void Update()
  {

  }
}
