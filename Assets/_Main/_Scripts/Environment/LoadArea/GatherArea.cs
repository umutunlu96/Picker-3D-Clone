using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GatherArea : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] int indexOfArea;
    [SerializeField] int collectableMultiplier = 10;

    [Header("Referances")]
    [SerializeField] OriginalRoadUp originalRoadUp;
    [SerializeField] Barrier barrier;
    public TextMeshProUGUI collectText;

    private int collectedObjects = 0;
    public bool checkCollectedCount = false;

    private void Start()
    {
        SetCollectText();
    }

    private void Update()
    {
        if (checkCollectedCount)
        {
            CheckPlayerFailOrPass();
        }
    }

    private void SetCollectText()
    {
        collectText.text = collectedObjects.ToString() + " / " + (indexOfArea * collectableMultiplier).ToString();
    }

    public void UpdateCollectText()
    {
        collectedObjects++;
        SetCollectText();
    }

    private void CheckPlayerFailOrPass()
    {
        StartCoroutine(Delay(2));

        if (collectedObjects >= indexOfArea * collectableMultiplier)
        {
            originalRoadUp.MoveUpwards();

            StartCoroutine(Delay(2));

            barrier.MoveBarrierUp();

            UiManager.instance.SetProggress(indexOfArea);
        }

        else
        {
            GameManager.instance.LoseLevel();
        }

        checkCollectedCount = false;
    }



    private IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);
    }
}