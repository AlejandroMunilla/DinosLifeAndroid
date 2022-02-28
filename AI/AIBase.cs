using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class AIBase : MonoBehaviour
{
    public Saurius saurius;
    public GameObject target;
    public float speed = 4;
    public enum State
    {
        Idle,
        Walk,
        Run,
        Follow,
        Sleep,
        Attack
    }
    [SerializeField]
    public State state;
    private bool alive = true;
    private NavMeshAgent nav;
    public Animation anim;
    private Rigidbody rb;

    public virtual IEnumerator FSM()
    {
        while (alive)
        {
            switch (state)
            {
                case State.Idle:
                    Idle();
                    yield return new WaitForSeconds(0.1f);
                    break;

                case State.Follow:
                    Follow();
                    yield return new WaitForSeconds(0.1f);
                    break;
            }
        }
        yield return new WaitForSeconds(0);
     
    }

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        //     anim = transform.GetChild(0).gameObject.GetComponent<Animation>();
        state = State.Idle;
        StartCoroutine("FSM");

        nav.isStopped = true;
    }

    private void Idle ()
    {
   //     Debug.Log(target);

        if (target != null)
        {
            float distance = Vector3.Distance(target.transform.position, transform.position);
            if (distance > 3)
            {
                state = State.Follow;
                nav.destination = target.transform.position;
                Debug.Log("Change");
                nav.speed = speed;
       //         nav.velocity = speed * Vector3.forward;
                nav.isStopped = false;
         //       rb.constraints = RigidbodyConstraints.None;
            }
            else if (!anim.IsPlaying("idle"))
            {
                anim.Play("idle");
       //         nav.velocity = Vector3.zero;
                nav.isStopped = true;
                
           //     rb.constraints = RigidbodyConstraints.FreezeAll;
            }

        }


    }

    private void Follow ()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);
        Debug.Log(distance);
        if (distance > 5)
        {

            nav.destination = target.transform.position;
            nav.isStopped = false;
            if (!anim.IsPlaying("run"))
            {
                anim.Play("run");
            }
            Debug.Log("pushed");
    
        }
        if (distance <= 5)
        {
            anim.Play("idle");
            nav.isStopped = true;
            if (!anim.IsPlaying("idle"))
            {
                anim.Play("idle");
              

            }
 
        }
    }
}
