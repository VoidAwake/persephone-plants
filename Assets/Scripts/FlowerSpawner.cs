using System;
using SonicBloom.Koreo.Demos;
using Unity.VisualScripting;
using UnityEngine;

public class FlowerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject flowerPrefab;
    [SerializeField] private RhythmGameController rhythmGameController;

    private GameObject currentFlower;

    private void Start()
    {
         currentFlower = Instantiate(flowerPrefab, transform);
    }

    private void OnEnable()
    {
        rhythmGameController.noteHit.AddListener(OnNoteHit);
        rhythmGameController.noteMissed.AddListener(OnNoteMissed);
    }
    
    
    private void OnDisable()
    {
        rhythmGameController.noteHit.RemoveListener(OnNoteHit);
        rhythmGameController.noteMissed.RemoveListener(OnNoteMissed);
    }

    private void OnNoteHit(string notePlayload)
    {
        if (notePlayload == "Z")
        {
            currentFlower.GetComponent<Animator>().SetTrigger("Shoot");
            currentFlower.GetComponent<FlowerController>().StartMoving();

            currentFlower = Instantiate(flowerPrefab, transform);
        }

        if (notePlayload == "X")
        {
            currentFlower.GetComponent<FlowerController>().ShowNextPetal();
        }
    }
    
    private void OnNoteMissed(string notePlayload)
    {
        if (notePlayload == "Z")
        {
            currentFlower.GetComponent<Animator>().SetTrigger("Drop");

            currentFlower = Instantiate(flowerPrefab, transform);
        }

        if (notePlayload == "X")
        {
            currentFlower.GetComponent<FlowerController>().SkipNextPetal();
        }
    }
}
