using UnityEngine;

public class ToyMachineOpenPoint : DropPoint
{
    private ToyMachine toyMachine; //ToyMachine compoenent of the parent
    private AudioSource audioSource; //AudioSource component

    /// <summary>
    /// Start method to initialize components
    /// </summary>
    private void Start()
    {
        toyMachine = GetComponentInParent<ToyMachine>();
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Method to define what to do when an item is dropped
    /// We play the sound effect and we add the part to the toy machine
    /// </summary>
    /// <param name="item">ItemSO dropped</param>
    public override void ItemDropped(ItemSO item)
    {
        audioSource.Play();
        toyMachine.AddToyPart(item);
    }

    /// <summary>
    /// Method to define what to do when a toy is dropped
    /// We return it to the last location
    /// </summary>
    /// <param name="toy">ToyObject dropped</param>
    public override void ToyDropped(ToyObject toy)
    {
        toy.ReturnToLastPoint();
    }
}
