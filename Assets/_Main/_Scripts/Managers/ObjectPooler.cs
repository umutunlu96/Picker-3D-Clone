using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler instance;

    [Header("Distance")]
    [SerializeField] private int Distance = 51;

    [Header("Levels")]
    [SerializeField] private GameObject Level1;
    [SerializeField] private GameObject Level2;
    [SerializeField] private GameObject Level3;
    
    [Header("Roads")]
    [SerializeField] private GameObject OriginalRoad1;
    [SerializeField] private GameObject OriginalRoad2;
    [SerializeField] private GameObject OriginalRoad3;

    [Header("Barriers")]
    [SerializeField] private GameObject[] Barrier1;
    [SerializeField] private GameObject[] Barrier2;
    [SerializeField] private GameObject[] Barrier3;

    [Header("Collectables of Level-1")]
    [SerializeField] public GameObject[] Collectables1;
    [SerializeField] public GameObject Tunnel;

    [Header("Collectables of Level-2")]
    [SerializeField] private GameObject WingUpgrade;
    [SerializeField] private GameObject HelicopterCollectablesParent;
    [SerializeField] private GameObject[] Collectables2;

    [Header("Collectables of Level-3")]
    [SerializeField] private GameObject[] Collectables3;


    [Header("Transform Of Objects")]
    private Vector3 level1T = new Vector3();
    private Vector3 level2T = new Vector3();
    private Vector3 level3T = new Vector3();
    private Vector3 originalRoad1T = new Vector3();
    private Vector3 originalRoad2T = new Vector3();
    private Vector3 originalRoad3T = new Vector3();
    private Vector3[] collectables1T= new Vector3[50];
    private Vector3[] collectables2T = new Vector3[60];
    private Vector3[] collectables3T = new Vector3[72];
    private Vector3 wingUpgradeT = new Vector3();
    private Quaternion[] barrierQ = new Quaternion[2];

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        GetLevel1Positions();
        GetLevel2Positions();
        GetLevel3Positions();
    }

    private void GetLevel1Positions()
    {
        level1T = Level1.transform.position;

        originalRoad1T = OriginalRoad1.transform.localPosition;

        for (int i = 0; i < Barrier1.Length; i++)
        {
            barrierQ[i] = Barrier1[i].transform.rotation;
        }

        for (int i = 0; i < Collectables1.Length; i++)
        {
            collectables1T[i] = Collectables1[i].transform.localPosition;
        }
    }

    private void SetLevel1Positions(int distance)
    {
        Level1.transform.position = level1T + new Vector3(0, 0, distance);

        OriginalRoad1.transform.localPosition = originalRoad1T;

        if (!Tunnel.activeInHierarchy)
            Tunnel.SetActive(true);

        for (int i = 0; i < Barrier1.Length; i++)
        {
            Barrier1[i].transform.rotation = barrierQ[i];
        }

        for (int i = 0; i < Collectables1.Length; i++)
        {
            Collectables1[i].transform.localPosition = collectables1T[i];
            Collectables1[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            Collectables1[i].transform.rotation = Quaternion.identity;
        }
    }

    private void GetLevel2Positions()
    {
        level2T = Level2.transform.position;

        originalRoad2T = OriginalRoad2.transform.localPosition;

        wingUpgradeT = WingUpgrade.transform.localPosition;

        for (int i = 0; i < Collectables2.Length; i++)
        {
            collectables2T[i] = Collectables2[i].transform.localPosition;
        }
    }


    private void SetLevel2Positions(int distance)
    {
        Level2.transform.position = level2T + new Vector3(0, 0, distance);

        OriginalRoad2.transform.localPosition = originalRoad2T;

        WingUpgrade.SetActive(true);
        WingUpgrade.transform.localPosition = wingUpgradeT;

        for (int i = 0; i < Barrier2.Length; i++)
        {
            Barrier2[i].transform.rotation = barrierQ[i];
        }

        for (int i = 0; i < Collectables2.Length; i++)
        {
            Collectables2[i].SetActive(false);
            Collectables2[i].transform.SetParent(HelicopterCollectablesParent.transform);
            Collectables2[i].transform.localPosition = collectables2T[i];
            Collectables2[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            Collectables2[i].transform.rotation = Quaternion.identity;
        }
    }

    private void GetLevel3Positions()
    {
        level3T = Level3.transform.position;

        originalRoad3T = OriginalRoad3.transform.localPosition;

        for (int i = 0; i < Collectables3.Length; i++)
        {
            collectables3T[i] = Collectables3[i].transform.localPosition;
        }
    }

    private void SetLevel3Positions(int distance)
    {
        Level3.transform.position = level3T + new Vector3(0, 0, distance);

        OriginalRoad3.transform.localPosition = originalRoad3T;

        for (int i = 0; i < Barrier3.Length; i++)
        {
            Barrier3[i].transform.rotation = barrierQ[i];
        }

        for (int i = 0; i < Collectables3.Length; i++)
        {
            Collectables3[i].transform.localPosition = collectables3T[i];
            Collectables3[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            Collectables3[i].transform.rotation = Quaternion.identity;
        }
    }

    public void GenerateLevel1()
    {
        SetLevel1Positions(Distance);
        GetLevel1Positions();
    }

    public void GenerateLevel2()
    {
        SetLevel2Positions(Distance);
        GetLevel2Positions();
    }

    public void GenerateLevel3()
    {
        SetLevel3Positions(Distance);
        GetLevel3Positions();
    }
}