using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    private Animator animator;
    public bool isAnimationCooldown;
    public Texture2D clickCursorTexture;
    public Vector2 clickHotSpot = Vector2.zero;
    public Texture2D defaultCursorTexture;
    public Vector2 defaultHotSpot = Vector2.zero;

    private void Start()
    {
        Cursor.SetCursor(defaultCursorTexture, defaultHotSpot, CursorMode.Auto);
        animator = GetComponent<Animator>();
        isAnimationCooldown = false;
    }

    private void Update()
    {
        bool animationChanged = false;

        if (Input.GetMouseButtonDown(0) && !isAnimationCooldown)
        {
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
            Invoke("ResetAnimationCooldown", 0.3f);
            animationChanged = true;
        }

        // Update the cursor texture only when the animation state changes
        if (animationChanged)
        {
            if (isAnimationCooldown)
            {
                Cursor.SetCursor(clickCursorTexture, clickHotSpot, CursorMode.Auto);
            }
            else
            {
                Cursor.SetCursor(defaultCursorTexture, defaultHotSpot, CursorMode.Auto);
            }
        }
    }

    private void ResetAnimationCooldown()
    {
        isAnimationCooldown = false;
        Cursor.SetCursor(defaultCursorTexture, defaultHotSpot, CursorMode.Auto);
    }
}
