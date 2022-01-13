using System;
using UnityEngine;
using UnityEngine.UI;

public class WrapPoint : DropPoint
{
    [SerializeField] private ToyMachine toyMachine; //ToyMachine
    [SerializeField] private LettersBox lettersBox; //LettersBox
    [SerializeField] private Button wrapButton; //Button to wrap the toy
    [SerializeField] private AudioClip correctToySound; //AudioClip for toys made right
    [SerializeField] private GameObject correctOrWrongToyPanel; //Panel that shows if the toy was right or wrong

    private bool correctHead, correctBody, correctLeftArm, correctRightArm, correctLeftLeg, correctRightLeg; //bools to determine if we have the correct body parts
    private Animator animator; //Animator component
    private AudioSource audioSource; //AudioSource component

    public static Action OnToyMadeRight; //Action for when a toy is made right
    public static Action<int> OnToyMadeWrong; //Action for when a toy is made wrong

    /// <summary>
    /// Method to initialize components
    /// </summary>
    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Method to do nothing if an item is dropped on us
    /// </summary>
    /// <param name="item">item dropped</param>
    public override void ItemDropped(ItemSO item)
    {
        return;
    }

    /// <summary>
    /// Method to save the new position for the toy that was dropped on us and to make the wrap button interactable
    /// </summary>
    /// <param name="toy">toy dropped</param>
    public override void ToyDropped(ToyObject toy)
    {
        toy.SavePosition(transform.position);
        wrapButton.interactable = true;
    }

    /// <summary>
    /// Method to wrap a toy
    /// We trigger the animation, destroy the previous toy, initialize the bools and save the toy parts of the created toy
    /// If we have more or less parts than necessary, the toy is wrong
    /// Otherwise, we check each part. If we already had that part, the toy is wrong and we end the method
    /// If we didn't have it, we check if it's the correct one, if it isn't, the toy is wrong and we end the method
    /// For arms and legs, we check both sides
    /// If every part is correct, the toy is right. We take a new letter, play a sound effect and activate the panel that indicates if we did it right or wrong in green
    /// </summary>
    public void WrapToy()
    {
        correctOrWrongToyPanel.SetActive(false);
        wrapButton.interactable = false;
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
    }

    /// <summary>
    /// Method for when the toy was made wrongly
    /// We play the sound effect and activate the panel indicator in red
    /// </summary>
    /// <param name="createdToyParts">ToyParts to tell the GameManager how many parts were wasted</param>
    private void WrongToy(ToyPart[] createdToyParts)
    {
        OnToyMadeWrong?.Invoke(createdToyParts.Length);
        audioSource.Play();
        correctOrWrongToyPanel.GetComponent<Image>().color = new Color(1, 0, 0, 0.3f);
        correctOrWrongToyPanel.SetActive(true);
    }
}
