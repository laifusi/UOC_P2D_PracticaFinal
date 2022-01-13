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

        for(int i = 0; i < items.Count; i++)
        {
            switch(items[i].bodyPart)
            {
                case Part.Head:
                    head.sprite = items[i].sprite;
                    break;
                case Part.Body:
                    body.sprite = items[i].sprite;
                    break;
                case Part.Arm:
                    leftArm.sprite = items[i].sprite;
                    rightArm.sprite = items[i].sprite;
                    break;
                case Part.Leg:
                    leftLeg.sprite = items[i].sprite;
                    rightLeg.sprite = items[i].sprite;
                    break;
            }
        }
    }
}
