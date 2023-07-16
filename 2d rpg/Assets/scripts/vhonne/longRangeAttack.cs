using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

#if Unity_Editor
using UnityEditor
#endif
public class longRangeAttack : MonoBehaviour
{
   [Header("needed")]
    public Rigidbody2D rb;
    public GameObject player;
    public GameObject attack;

    [Header("customable")]
    public Transform bulletPos;
    public float damage = 0;
    public float attackInterval = 0;
    float timer = 0;
    public float speedAttack = 0;

    [Header("animation")]
    public bool hasAnimation;
    Animator animator;
    string animationName;

    AIDestinationSetter ADS;

    AIPath Ap;
 
    public class longRangeAttackEditor : Editor
    {
        public override void OnInspectorGUI ()
        {
            base.OnInspectorGUI ();

            longRangeAttack lRA = (longRangeAttack)target;

            if (lRA.hasAnimation)
            {
                EditorGUI.indentLevel ++;
                lRA.animator = EditorGUILayout.ObjectField("animator", lRA.animator, typeof(Animator), true) as Animator;
                lRA.animationName = EditorGUILayout.TextField("name", lRA.animationName);
                EditorGUI.indentLevel--;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if(hasAnimation) animator = GetComponent<Animator>();

        if(animator != null)
        {
            animator = GetComponentInChildren<Animator>();
        }

        ADS = GetComponent<AIDestinationSetter>();
        Ap= GetComponent<AIPath>();
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Vector2.Distance(transform.position, player.transform.position) <= ADS.distanceChase)
        {
            if (timer >= attackInterval && Ap.endReachedDistance >= Vector2.Distance(transform.position, player.transform.position))    
            {
                CreateAttack();
                timer = 0;
            }
            else
            {
                timer += Time.deltaTime;
            }

            Vector3 direction = player.transform.position - transform.position;
            float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            Transform shooter = GetComponentInChildren<Transform>();
            transform.rotation = Quaternion.Euler(0, 0, rot + 184);
        }
    }

    void CreateAttack()
    {
    
        GameObject bullet = Instantiate(attack, bulletPos.position, Quaternion.identity);
    }
}
