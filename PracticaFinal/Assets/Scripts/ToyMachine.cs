using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyMachine : MonoBehaviour
{
    private Toy createdToy;
    private ToyPart[] toyParts;
    private List<ItemSO> items = new List<ItemSO>();

    [SerializeField] private GameObject toyPrefab;
    [SerializeField] private Transform exitPoint;
    [SerializeField] private GameObject extraPartPrefab;

    private GameObject toy;
    private SpriteRenderer[] toySpriteRenderers;
    private SpriteRenderer head, body, leftArm, rightArm, leftLeg, rightLeg;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void AddToyPart(ItemSO item)
    {
        animator.SetTrigger("AddPart");
        items.Add(item);
    }

    public void MakeToy()
    {
        toy = Instantiate(toyPrefab, exitPoint.position, Quaternion.identity);
        toySpriteRenderers = toy.GetComponentsInChildren<SpriteRenderer>();
        head = toySpriteRenderers[0];
        body = toySpriteRenderers[1];
        leftArm = toySpriteRenderers[2];
        rightArm = toySpriteRenderers[3];
        leftLeg = toySpriteRenderers[4];
        rightLeg = toySpriteRenderers[5];

        toyParts = new ToyPart[items.Count];

        for(int i = 0; i < items.Count; i++)
        {
            ToyPart part;
            part.bodyPart = items[i].bodyPart;
            part.typeOfToy = items[i].typeOfToy;
            toyParts[i] = part;

            switch(items[i].bodyPart)
            {
                case Part.Head:
                    if (head.sprite == null)
                    {
                        head.sprite = items[i].sprite;
                    }
                    else
                    {
                        GameObject extraPart = Instantiate(extraPartPrefab, head.transform.position, Quaternion.identity, toy.transform);
                        extraPart.transform.Rotate(0, 0, Random.Range(-15f, 15f));
                        extraPart.GetComponent<SpriteRenderer>().sprite = items[i].sprite;
                    }
                    break;
                case Part.Body:
                    if (body.sprite == null)
                    {
                        body.sprite = items[i].sprite;
                    }
                    else
                    {
                        GameObject extraPart = Instantiate(extraPartPrefab, body.transform.position, Quaternion.identity, toy.transform);
                        extraPart.transform.Rotate(0, 0, Random.Range(-15, 15f));
                        extraPart.GetComponent<SpriteRenderer>().sprite = items[i].sprite;
                    }
                    break;
                case Part.Arm:
                    if(leftArm.sprite == null)
                    {
                        if (Letter.ToyToMake.toyParts[2].typeOfToy == items[i].typeOfToy)
                        {
                            leftArm.sprite = items[i].sprite;
                        }
                        else if (Letter.ToyToMake.toyParts[3].typeOfToy == items[i].typeOfToy)
                        {
                            if (rightArm.sprite == null)
                            {
                                rightArm.sprite = items[i].sprite;
                            }
                            else
                            {
                                leftArm.sprite = rightArm.sprite;
                                rightArm.sprite = items[i].sprite;
                            }
                        }
                        else
                        {
                            leftArm.sprite = items[i].sprite;
                        }
                    }
                    else if(rightArm.sprite == null)
                    {
                        if (Letter.ToyToMake.toyParts[3].typeOfToy == items[i].typeOfToy)
                        {
                            rightArm.sprite = items[i].sprite;
                        }
                        else if(Letter.ToyToMake.toyParts[2].typeOfToy == items[i].typeOfToy)
                        {
                            rightArm.sprite = leftArm.sprite;
                            leftArm.sprite = items[i].sprite;
                        }
                        else
                        {
                            rightArm.sprite = items[i].sprite;
                        }
                    }
                    else
                    {
                        int randomArmID = Random.Range(0, 2);
                        Transform armToUse;
                        if (randomArmID == 0)
                        {
                            armToUse = rightArm.transform;
                        }
                        else
                        {
                            armToUse = leftArm.transform;
                        }

                        GameObject extraPart = Instantiate(extraPartPrefab, armToUse.transform.position, Quaternion.identity, toy.transform);
                        extraPart.transform.Rotate(0, 0, Random.Range(-15f, 15f));
                        extraPart.GetComponent<SpriteRenderer>().sprite = items[i].sprite;
                    }
                    break;
                case Part.Leg:
                    if (leftLeg.sprite == null)
                    {
                        if (Letter.ToyToMake.toyParts[4].typeOfToy == items[i].typeOfToy)
                        {
                            leftLeg.sprite = items[i].sprite;
                        }
                        else if (Letter.ToyToMake.toyParts[5].typeOfToy == items[i].typeOfToy)
                        {
                            if (rightLeg.sprite == null)
                            {
                                rightLeg.sprite = items[i].sprite;
                            }
                            else
                            {
                                leftLeg.sprite = rightLeg.sprite;
                                rightLeg.sprite = items[i].sprite;
                            }
                        }
                        else
                        {
                            leftLeg.sprite = items[i].sprite;
                        }
                    }
                    else if (rightLeg.sprite == null)
                    {
                        if (Letter.ToyToMake.toyParts[5].typeOfToy == items[i].typeOfToy)
                        {
                            rightLeg.sprite = items[i].sprite;
                        }
                        else if (Letter.ToyToMake.toyParts[4].typeOfToy == items[i].typeOfToy)
                        {
                            rightLeg.sprite = leftLeg.sprite;
                            leftLeg.sprite = items[i].sprite;
                        }
                        else
                        {
                            rightLeg.sprite = items[i].sprite;
                        }
                    }
                    else
                    {
                        int randomLegID = Random.Range(0, 2);
                        Transform legToUse;
                        if (randomLegID == 0)
                        {
                            legToUse = rightLeg.transform;
                        }
                        else
                        {
                            legToUse = leftLeg.transform;
                        }

                        GameObject extraPart = Instantiate(extraPartPrefab, legToUse.transform.position, Quaternion.identity, toy.transform);
                        extraPart.transform.Rotate(0, 0, Random.Range(-15f, 15f));
                        extraPart.GetComponent<SpriteRenderer>().sprite = items[i].sprite;
                    }
                    break;
            }
        }
    }
}
