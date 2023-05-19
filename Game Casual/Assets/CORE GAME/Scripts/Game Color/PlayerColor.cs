using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    public int ColorId;

    private void Awake()
    {
        GetComponent<SpriteRenderer>().color = GameplayManager.Instance.Colors[ColorId];
    }
}
