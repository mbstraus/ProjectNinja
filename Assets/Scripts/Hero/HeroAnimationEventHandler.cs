using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAnimationEventHandler : MonoBehaviour
{
    [SerializeField]
    private HeroController heroController;

    public void StopAttack() {
        heroController.StopAttack();
    }
}
