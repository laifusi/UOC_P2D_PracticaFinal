using System.Collections.Generic;
using UnityEngine;

public class ToyMachine : MonoBehaviour
{
    [HideInInspector] public Toy createdToy; //Toy we created
    private ToyPart[] toyParts; //ToyParts of the toy we created
    private List<ItemSO> items = new List<ItemSO>(); //items added

    [SerializeField] private GameObject toyPrefab; //Prefab of a full toy
    [SerializeField] private Transform exitPoint; //Transform of the exit point
    [SerializeField] private GameObject extraPartPrefab; //Prefab for extra parts

    private GameObject toy; //GameObject of the toy
    private SpriteRenderer[] toySpriteRenderers; //SpriteRenderers of the toy prefab
    private SpriteRenderer head, body, leftArm, rightArm, leftLeg, rightLeg; //spriteRenderers of the toy prefab assigned to body part
    private Animator animator; //Animator component

    /// <summary>
    /// Start method to initialize components
    /// </summary>
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Method to add an item to the machine
    /// Called when an item is dropped on the opening point of the machine
    /// </summary>
    /// <param name="item"></param>
    public void AddToyPart(ItemSO item)
    {
        animator.SetTrigger("AddPart");
        items.Add(item);
    }

    /// <summary>
    /// Method to make the toy
    /// Called by the MakeToy button
    /// We destroy the previous toy if it hadn't been destroyed
    /// We instantiate the prefab and save its sprite renderers
    /// We check add each body part, for each item we save it as a ToyPart
    /// We check which body part it is and add the sprites to the right Sprite Renderers
    /// If we already have that body part, we add an extra part, with a slight rotation
    /// For the arms and legs, we check if they are the correct type for either right or left and set it to its side if it is
    /// If it's neither and we already have both sprites, we choose a random arm or leg to add the extra part to
    /// We save the parts to the Toy and clear the items list
    /// </summary>
    public void MakeToy()
    {
        if (toy != null)
            DestroyToyGameObject();

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

        createdToy = new Toy(toyParts);
        items.Clear();
    }

    /// <summary>
    /// Method to destroy the toy GameObject
    /// </summary>
    public void DestroyToyGameObject()
    {
        Destroy(toy);
    }
}
