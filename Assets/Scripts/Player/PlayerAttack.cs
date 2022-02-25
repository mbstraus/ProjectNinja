using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class PlayerAttack : MonoBehaviour
{
    private Vector2 AttackVector;
    private bool IsAttacking;
    [SerializeField]
    public float SwingSpeed = 0.2f;

    [SerializeField]
    public Sword Sword;

    void Update() {
        if (AttackVector != Vector2.zero && !IsAttacking) {
            IsAttacking = true;
            Sword.gameObject.SetActive(true);
            Sequence sequence = DOTween.Sequence();
            if (AttackVector.y > 0) {
                Sword.transform.localEulerAngles = new Vector3(0f, 0f, 50f);
                sequence.Append(Sword.transform.DOLocalRotate(new Vector3(0f, 0f, 310f), SwingSpeed));
            } else if (AttackVector.y < 0) {
                Sword.transform.localEulerAngles = new Vector3(0f, 0f, 220f);
                sequence.Append(Sword.transform.DOLocalRotate(new Vector3(0f, 0f, 130f), SwingSpeed));
            } else if (AttackVector.x < 0) {
                Sword.transform.localEulerAngles = new Vector3(0f, 0f, 130f);
                sequence.Append(Sword.transform.DOLocalRotate(new Vector3(0f, 0f, 50f), SwingSpeed));
            } else {
                Sword.transform.localEulerAngles = new Vector3(0f, 0f, 310f);
                sequence.Append(Sword.transform.DOLocalRotate(new Vector3(0f, 0f, 220f), SwingSpeed));
            }
            sequence.OnComplete(AttackComplete);
            sequence.Play();
        }
    }

    public void Attack(InputAction.CallbackContext callbackContext) {
        AttackVector = callbackContext.ReadValue<Vector2>();
    }

    public void AttackComplete() {
        IsAttacking = false;
        Sword.gameObject.SetActive(false);
    }
}
