using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour
{
    [SerializeField] private ItemSO[] possibleHeads, possibleBodies, possibleArms, possibleLegs;
    [SerializeField] private SpriteRenderer head, body, leftArm, rightArm, leftLeg, rightLeg;

    public static Toy ToyToMake;

    private ToyPart headPart, bodyPart, leftArmPart, rightArmPart, leftLegPart, rightLegPart;

    public void OpenNewLetter()
    {
        int randomHeadID = Random.Range(0, possibleHeads.Length);
        int randomBodyID = Random.Range(0, possibleBodies.Length);
        //int randomArmID = Random.Range(0, possibleArms.Length);
        //int randomLegID = Random.Range(0, possibleLegs.Length);
        int randomLeftArmID = Random.Range(0, possibleArms.Length);
        int randomLeftLegID = Random.Range(0, possibleLegs.Length);
        int randomRightArmID = Random.Range(0, possibleArms.Length);
        int randomRightLegID = Random.Range(0, possibleLegs.Length);

        head.sprite = possibleHeads[randomHeadID].sprite;
        body.sprite = possibleBodies[randomBodyID].sprite;
        //leftArm.sprite = possibleArms[randomArmID].sprite;
        //leftLeg.sprite = possibleLegs[randomLegID].sprite;
        //rightArm.sprite = possibleArms[randomArmID].sprite;
        //rightLeg.sprite = possibleLegs[randomLegID].sprite;
        leftArm.sprite = possibleArms[randomLeftArmID].sprite;
        leftLeg.sprite = possibleLegs[randomLeftLegID].sprite;
        rightArm.sprite = possibleArms[randomRightArmID].sprite;
        rightLeg.sprite = possibleLegs[randomRightLegID].sprite;

        headPart.bodyPart = Part.Head;
        headPart.typeOfToy = possibleHeads[randomHeadID].typeOfToy;
        bodyPart.bodyPart = Part.Body;
        bodyPart.typeOfToy = possibleBodies[randomBodyID].typeOfToy;
        leftArmPart.bodyPart = Part.Arm;
        //leftArmPart.typeOfToy = possibleArms[randomArmID].typeOfToy;
        leftArmPart.typeOfToy = possibleArms[randomLeftArmID].typeOfToy;
        leftLegPart.bodyPart = Part.Leg;
        //leftLegPart.typeOfToy = possibleLegs[randomLegID].typeOfToy;
        leftLegPart.typeOfToy = possibleLegs[randomLeftLegID].typeOfToy;
        rightArmPart.bodyPart = Part.Arm;
        //rightArmPart.typeOfToy = possibleArms[randomArmID].typeOfToy;
        rightArmPart.typeOfToy = possibleArms[randomRightArmID].typeOfToy;
        rightLegPart.bodyPart = Part.Leg;
        //rightLegPart.typeOfToy = possibleLegs[randomLegID].typeOfToy;
        rightLegPart.typeOfToy = possibleLegs[randomRightLegID].typeOfToy;

        ToyPart[] parts = new ToyPart[6];
        parts[0] = headPart;
        parts[1] = bodyPart;
        parts[2] = leftArmPart;
        parts[3] = rightArmPart;
        parts[4] = leftLegPart;
        parts[5] = rightLegPart;
        ToyToMake = new Toy(parts);
    }
}
