using UnityEngine;
using UnityEngine.UI;

public class WrapPoint : DropPoint
{
    [SerializeField] private ToyMachine toyMachine;
    [SerializeField] private LettersBox lettersBox;
    [SerializeField] private Button wrapButton;

    private bool correctHead, correctBody, correctLeftArm, correctRightArm, correctLeftLeg, correctRightLeg;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public override void ItemDropped(ItemSO item)
    {
        return;
    }

    public override void ToyDropped(ToyObject toy)
    {
        toy.SavePosition(transform.position);
        wrapButton.interactable = true;
    }

    public void WrapToy()
    {
        animator.SetTrigger("WrapGift");
        toyMachine.DestroyToyGameObject();
        correctHead = correctBody = correctLeftArm = correctRightArm = correctLeftLeg = correctRightLeg = false;
        ToyPart[] createdToyParts = toyMachine.createdToy.toyParts;
        if (createdToyParts.Length != Letter.ToyToMake.toyParts.Length)
        {
            Debug.Log("Wrong");
        }
        else
        {
            for(int i = 0; i < createdToyParts.Length; i++)
            {
                switch(createdToyParts[i].bodyPart)
                {
                    case Part.Head:
                        if(correctHead)
                        {
                            Debug.Log("Wrong");
                            return;
                        }
                        else
                        {
                            if(createdToyParts[i].typeOfToy == Letter.ToyToMake.toyParts[0].typeOfToy)
                            {
                                correctHead = true;
                            }
                            else
                            {
                                Debug.Log("Wrong");
                                return;
                            }
                        }
                        break;
                    case Part.Body:
                        if (correctBody)
                        {
                            Debug.Log("Wrong");
                            return;
                        }
                        else
                        {
                            if (createdToyParts[i].typeOfToy == Letter.ToyToMake.toyParts[1].typeOfToy)
                            {
                                correctBody = true;
                            }
                            else
                            {
                                Debug.Log("Wrong");
                                return;
                            }
                        }
                        break;
                    case Part.Arm:
                        if(correctLeftArm)
                        {
                            if(correctRightArm)
                            {
                                Debug.Log("Wrong");
                                return;
                            }
                            else if(createdToyParts[i].typeOfToy == Letter.ToyToMake.toyParts[3].typeOfToy)
                            {
                                correctRightArm = true;
                            }
                            else
                            {
                                Debug.Log("Wrong");
                                return;
                            }
                        }
                        else
                        {
                            if (createdToyParts[i].typeOfToy == Letter.ToyToMake.toyParts[2].typeOfToy)
                            {
                                correctLeftArm = true;
                            }
                            else if(!correctRightArm && createdToyParts[i].typeOfToy == Letter.ToyToMake.toyParts[3].typeOfToy)
                            {
                                correctRightArm = true;
                            }
                            else
                            {
                                Debug.Log("Wrong");
                                return;
                            }
                        }
                        break;
                    case Part.Leg:
                        if (correctLeftLeg)
                        {
                            if (correctRightLeg)
                            {
                                Debug.Log("Wrong");
                                return;
                            }
                            else if (createdToyParts[i].typeOfToy == Letter.ToyToMake.toyParts[5].typeOfToy)
                            {
                                correctRightLeg = true;
                            }
                            else
                            {
                                Debug.Log("Wrong");
                                return;
                            }
                        }
                        else
                        {
                            if (createdToyParts[i].typeOfToy == Letter.ToyToMake.toyParts[4].typeOfToy)
                            {
                                correctLeftLeg = true;
                            }
                            else if (!correctRightLeg && createdToyParts[i].typeOfToy == Letter.ToyToMake.toyParts[5].typeOfToy)
                            {
                                correctRightLeg = true;
                            }
                            else
                            {
                                Debug.Log("Wrong");
                                return;
                            }
                        }
                        break;
                }
            }
        }


        if (correctHead && correctBody && correctLeftArm && correctLeftLeg && correctRightArm && correctRightLeg)
        {
            lettersBox.TakeLetter();
        }
        wrapButton.interactable = false;
    }
}
