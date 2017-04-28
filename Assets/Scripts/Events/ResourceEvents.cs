using UnityEngine.Events;

[System.Serializable]
public class IncreaseValueEvent : UnityEvent<int> { }

[System.Serializable]
public class DecreaseValueEvent : UnityEvent<int> { }

[System.Serializable]
public class SetResourceTypeEvent : UnityEvent<ResourceType> { }