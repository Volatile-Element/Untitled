using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;

public class Resource : MonoBehaviour
{
    public ResourceType Type;
    public int Value = 0;

    public UnityEvent<int> IncreaseValue;
    public UnityEvent<int> DecreaseValue;
    public UnityEvent<ResourceType> SetResourceType;



    // Use this for initialization
    void Start()
    {
        IncreaseValue = new IncreaseValueEvent();
        DecreaseValue = new DecreaseValueEvent();
        SetResourceType = new SetResourceTypeEvent();

        IncreaseValue.AddListener(IncreaseValueEvent);
        DecreaseValue.AddListener(DecreaseValueEvent);
        SetResourceType.AddListener(SetResourceTypeEvent);
    }

    private void SetResourceTypeEvent(ResourceType value)
    {
        Type = value;
    }

    private void DecreaseValueEvent(int value)
    {
        Value -= value;
        Debug.Log("Value for " + Type.ToString() + " is " + Value);
    }

    private void IncreaseValueEvent(int value)
    {
        Value += value;
        Debug.Log("Value for " + Type.ToString() + " is " + Value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


