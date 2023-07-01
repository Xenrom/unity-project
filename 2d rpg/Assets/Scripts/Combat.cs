using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    private Animator animator;
    private bool isAnimationCooldown;

    private void Start()
    {
        animator = GetComponent<Animator>();
        isAnimationCooldown = false;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isAnimationCooldown){
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = mousePosition - (Vector2)transform.position;
            direction.Normalize();

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            float roundedAngle = Mathf.Round(angle / 90) * 90;

            if (roundedAngle == 0)
            {
                animator.Play("SlashRight");
            }
            else if (roundedAngle == 90)
            {
                animator.Play("SlashUp");
            }
            else if (roundedAngle == -180 || roundedAngle == 180)
            {
                animator.Play("SlashLeft");
            }
            else if (roundedAngle == -90)
            {
                animator.Play("SlashDown");
            }

            isAnimationCooldown = true;
            Invoke("ResetAnimationCooldown", 0.35f);
        }
    }
    private void ResetAnimationCooldown()
    {
        isAnimationCooldown = false;
    }
}