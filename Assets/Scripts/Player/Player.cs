using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using System;

public class Player : MonoBehaviour
{
    public int Id;
    public int TeamId;

    public List<Resource> Resources;

    //public List<Component> Resources;

    private void Awake()
    {
        foreach(var e in Enum.GetValues(typeof(ResourceType)))
        {
            var resource = gameObject.AddComponent<Resource>();
            var type = (ResourceType)Enum.Parse(typeof(ResourceType), e.ToString());
            resource.Type = type;
            Resources.Add(resource);
        }
    }

    public Resource GetResourceByResourceType(ResourceType type)
    {
        return Resources.Find(x => x.Type == type);
    }
}
