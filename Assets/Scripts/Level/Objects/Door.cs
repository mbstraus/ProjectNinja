using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    public Sprite DoorOpenSprite;
    [SerializeField]
    public Sprite DoorClosedSprite;
    [SerializeField]
    public bool IsOpen;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        SetDoorState(IsOpen);
    }

    public void SetDoorState(bool isDoorOpen) {
        IsOpen = isDoorOpen;
        if (IsOpen) {
            spriteRenderer.sprite = DoorOpenSprite;
        } else {
            spriteRenderer.sprite = DoorClosedSprite;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("Collided with " + this.name);
    }
}
