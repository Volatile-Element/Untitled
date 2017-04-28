using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System;

public class ResourceGiver : MonoBehaviour
{
    public ResourceType ResourceType;
    public Player HoldingPlayer;

    public int ResourceValue;

    public UnityEvent<Player> SetNewHoldingPlayer;
    public UnityEvent<int> SetResourceValue;

    public bool AddResource;

    public ResourceGiver(ResourceType type)
    {
        ResourceType = type;
    }

    // Use this for initialization
    void Start()
    {
        SetNewHoldingPlayer = new SetNewHoldingPlayerEvent();
        SetResourceValue = new SetResourceValueEvent();

        SetNewHoldingPlayer.AddListener(SetNewHoldingPlayerListener);
        SetResourceValue.AddListener(SetResourceValueListener);
        AddResource = true;
        InvokeRepeating("StartAddResource", 5, 5);
    }

    private void SetNewHoldingPlayerListener(Player value)
    {
        HoldingPlayer = value;
    }

    private void SetResourceValueListener(int value)
    {
        ResourceValue = value;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void StartAddResource()
    {
        if(AddResource && HoldingPlayer != null)
        {
            HoldingPlayer.GetResourceByResourceType(ResourceType).IncreaseValue.Invoke(ResourceValue);
        }
    }


}
