using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //h2o card to appear
    public GameObject go_h2oCard;
    public GameObject go_h1Card;
    public GameObject go_h2Card;

    //gameobject to relocate for seamlessness of animation
    public GameObject go_h1Sphere;
    public GameObject go_h2Sphere;

    //for retaing the original scale because of relocation and parent can have effect on scaling
    private Vector3 orginal_go_h1Sphere_scale;
    private Vector3 orginal_go_h2Sphere_scale;

    void Start()
    {
        //intializing
        orginal_go_h1Sphere_scale = go_h1Sphere.transform.localScale;
        orginal_go_h2Sphere_scale = go_h2Sphere.transform.localScale;

        //deactivating h2o card at the start
        go_h2oCard.SetActive(false);
    }

    void Update()
    {
            ImageTargetLogic();
    }

    private void ImageTargetLogic()
    {
        //relocation logic
        if (Utility.has_h1_o_Collided == true)
            Relocate_h1_To_o();
        else
            StartCoroutine(Relocate_oTo_h1_CoRoutine());

        if (Utility.has_h2_o_Collided == true)
            Relocate_h2_To_o();
        else
            StartCoroutine(Relocate_oTo_h2_CoRoutine());

        //h2o card appear and animation play logic
        if (Utility.has_h1_o_Collided == true && Utility.has_h2_o_Collided == true)
        {
            //play anim to go into merge animation
            Invoke("PlayMergeAnimation", 0.8f);
            //===for h2o card to appear===
            go_h2oCard.SetActive(true);
            go_h1Card.SetActive(false);
            go_h2Card.SetActive(false);

        }
        else
        {
            //===for h2o card to disappear===
            go_h2oCard.SetActive(false);
            go_h1Card.SetActive(true);
            go_h2Card.SetActive(true);

            //play anim to go into idle animation and then relocate
            Invoke("PlayIdleAnimation", 0f);

        }
    }

    public void PlayIdleAnimation()
    {
        var ator = GameObject.FindGameObjectWithTag("o").GetComponent<Animator>();
        ator.SetBool("toMerge", false);
    }

    public void PlayMergeAnimation()
    {
        var ator = GameObject.FindGameObjectWithTag("o").GetComponent<Animator>();
        ator.SetBool("toMerge", true);
    }


    private void Relocate_o_to_h1()
    {
        var go_h1 = GameObject.FindGameObjectWithTag("h1");
        go_h1Sphere.transform.parent = go_h1.transform;
        go_h1Sphere.transform.localPosition = new Vector3(0, 0, 0);
        go_h1Sphere.transform.localRotation = Quaternion.identity;
        go_h1Sphere.transform.localScale = orginal_go_h1Sphere_scale;
    }

    private void Relocate_h1_To_o()
    {
        var go_h1cue = GameObject.FindGameObjectWithTag("h1_cue");
        go_h1Sphere.transform.parent = go_h1cue.transform;
        go_h1Sphere.transform.localPosition = new Vector3(0, 0, 0);
        go_h1Sphere.transform.localRotation = Quaternion.identity;
        go_h1Sphere.transform.localScale = orginal_go_h1Sphere_scale;
    }

    private void Relocate_o_To_h2()
    {
        var go_h2 = GameObject.FindGameObjectWithTag("h2");
        go_h2Sphere.transform.parent = go_h2.transform;
        go_h2Sphere.transform.localPosition = new Vector3(0, 0, 0);
        go_h2Sphere.transform.localRotation = Quaternion.identity;
        go_h2Sphere.transform.localScale = orginal_go_h2Sphere_scale;
    }

    IEnumerator Relocate_oTo_h2_CoRoutine()
    {
        yield return new WaitForSeconds(1f);
        Relocate_o_To_h2();
    }
    IEnumerator Relocate_oTo_h1_CoRoutine()
    {
        yield return new WaitForSeconds(1f);
        Relocate_o_to_h1();
    }

    private void Relocate_h2_To_o()
    {
        var go_h2cue = GameObject.FindGameObjectWithTag("h2_cue");
        go_h2Sphere.transform.parent = go_h2cue.transform;
        go_h2Sphere.transform.localPosition = new Vector3(0, 0, 0);
        go_h2Sphere.transform.localRotation = Quaternion.identity;
        go_h2Sphere.transform.localScale = orginal_go_h2Sphere_scale;
    }
}
