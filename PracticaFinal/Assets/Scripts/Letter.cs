using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour
{
    [SerializeField] private ItemSO[] possibleHeads, possibleBodies, possibleArms, possibleLegs;
    [SerializeField] private SpriteRenderer head, body, leftArm, rightArm, leftLeg, rightLeg;

    public void OpenNewLetter()
    {
        int randomHeadID = Random.Range(0, possibleHeads.Length);
        int randomBodyID = Random.Range(0, possibleBodies.Length);
        int randomLeftArmID = Random.Range(0, possibleArms.Length);
        int randomLeftLegID = Random.Range(0, possibleLegs.Length);
        int randomRightArmID = Random.Range(0, possibleArms.Length);
        int randomRightLegID = Random.Range(0, possibleLegs.Length);

        head.sprite = possibleHeads[randomHeadID].sprite;
        body.sprite = possibleBodies[randomBodyID].sprite;
        leftArm.sprite = possibleArms[randomLeftArmID].sprite;
        leftLeg.sprite = possibleLegs[randomLeftLegID].sprite;
        rightArm.sprite = possibleArms[randomRightArmID].sprite;
        rightLeg.sprite = possibleLegs[randomRightLegID].sprite;
    }
}
