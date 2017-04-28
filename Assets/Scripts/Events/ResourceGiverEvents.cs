using UnityEngine.Events;

[System.Serializable]
public class SetNewHoldingPlayerEvent : UnityEvent<Player> { }

[System.Serializable]
public class SetResourceValueEvent : UnityEvent<int> { }