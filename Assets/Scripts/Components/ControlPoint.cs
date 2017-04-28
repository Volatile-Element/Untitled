using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System;

public class ControlPoint : MonoBehaviour
{
    public ResourceGiver ResourceGiver;
    public ResourceType ResourceType;
    public Player HoldingPlayer;

    public int ResourceValue;

    public UnityEvent<Player> ControlPointCaptured;
    

    // Use this for initialization
    void Start()
    {
        ControlPointCaptured = new ControlPointCapturedEvent();
        ControlPointCaptured.AddListener(ControlPointCapturedListener);

        ResourceGiver = this.GetOrAddComponent<ResourceGiver>();
        ResourceGiver.ResourceType = ResourceType;

        ResourceValue = 5;
    }

    private void ControlPointCapturedListener(Player value)
    {
        HoldingPlayer = value;
        ResourceGiver.SetResourceValue.Invoke(ResourceValue);
        ResourceGiver.SetNewHoldingPlayer.Invoke(value);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        var player = collision.gameObject.GetComponent<Player>();

        if(player != null && player != HoldingPlayer)
        {
            ControlPointCaptured.Invoke(player);
        }
    }
}
