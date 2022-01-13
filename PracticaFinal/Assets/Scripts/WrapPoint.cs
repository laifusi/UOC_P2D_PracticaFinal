using System;
using UnityEngine;
using UnityEngine.UI;

public class WrapPoint : DropPoint
{
    [SerializeField] private ToyMachine toyMachine;
    [SerializeField] private LettersBox lettersBox;
    [SerializeField] private Button wrapButton;
    [SerializeField] private AudioClip correctToySound;
    [SerializeField] private GameObject correctOrWrongToyPanel;

    private bool correctHead, correctBody, correctLeftArm, correctRightArm, correctLeftLeg, correctRightLeg;
    private Animator animator;
    private AudioSource audioSource;

    public static Action OnToyMadeRight;
    public static Action<int> OnToyMadeWrong;

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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
        correctOrWrongToyPanel.SetActive(false);
        animator.SetTrigger("WrapGift");
        toyMachine.DestroyToyGameObject();
        correctHead = correctBody = correctLeftArm = correctRightArm = correctLeftLeg = correctRightLeg = false;
        ToyPart[] createdToyParts = toyMachine.createdToy.toyParts;
        if (createdToyParts.Length != Letter.ToyToMake.toyParts.Length)
        {
            WrongToy(createdToyParts);
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
                            WrongToy(createdToyParts);
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
                                WrongToy(createdToyParts);
                                return;
                            }
                        }
                        break;
                    case Part.Body:
                        if (correctBody)
                        {
                            WrongToy(createdToyParts);
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
                                WrongToy(createdToyParts);
                                return;
                            }
                        }
                        break;
                    case Part.Arm:
                        if(correctLeftArm)
                        {
                            if(correctRightArm)
                            {
                                WrongToy(createdToyParts);
                                return;
                            }
                            else if(createdToyParts[i].typeOfToy == Letter.ToyToMake.toyParts[3].typeOfToy)
                            {
                                correctRightArm = true;
                            }
                            else
                            {
                                WrongToy(createdToyParts);
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
                                WrongToy(createdToyParts);
                                return;
                            }
                        }
                        break;
                    case Part.Leg:
                        if (correctLeftLeg)
                        {
                            if (correctRightLeg)
                            {
                                WrongToy(createdToyParts);
                                return;
                            }
                            else if (createdToyParts[i].typeOfToy == Letter.ToyToMake.toyParts[5].typeOfToy)
                            {
                                correctRightLeg = true;
                            }
                            else
                            {
                                WrongToy(createdToyParts);
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
                                WrongToy(createdToyParts);
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
            OnToyMadeRight?.Invoke();
            audioSource.PlayOneShot(correctToySound);
            correctOrWrongToyPanel.GetComponent<Image>().color = new Color(0, 1, 0, 0.3f);
            correctOrWrongToyPanel.SetActive(true);
        }
        wrapButton.interactable = false;
    }

    private void WrongToy(ToyPart[] createdToyParts)
    {
        OnToyMadeWrong?.Invoke(createdToyParts.Length);
        audioSource.Play();
        correctOrWrongToyPanel.GetComponent<Image>().color = new Color(1, 0, 0, 0.3f);
        correctOrWrongToyPanel.SetActive(true);
    }
}
