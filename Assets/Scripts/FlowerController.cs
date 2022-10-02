using System;
using System.Collections.Generic;
using UnityEngine;

public class FlowerController : MonoBehaviour
{
    [SerializeField] private List<GameObject> petals;
    [SerializeField] private float speed;

    private int nextPetalIndex;
    private bool isMoving;
        
    public void ShowNextPetal()
    {
        if (petals.Count >= nextPetalIndex)
        {
            petals[nextPetalIndex].SetActive(true);

            nextPetalIndex++;
        }
    }

    public void SkipNextPetal()
    {
        if (petals.Count >= nextPetalIndex)
        {
            nextPetalIndex++;
        }
    }

    private void Start()
    {
        foreach (var petal in petals)
        {
            petal.SetActive(false);
        }
    }

    public void StartMoving()
    {
        isMoving = true;
    }

    private void Update()
    {
        if (isMoving)
            transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}