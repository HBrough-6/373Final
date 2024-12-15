using System.Collections;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;



public class SlotMachine : Interactable
{
    [SerializeField] private float[] slotsRotations = { 0, 35, 70, 105, 135, 165, 195, 230, 265, 295, 325 };

    [SerializeField] private Transform wheelParent;
    [SerializeField] private Transform LightsParent;
    [SerializeField] private Transform CamPos;

    [SerializeField] private float[] results;
    private Animator animator;

    private Transform wheel1;
    private Transform wheel2;
    private Transform wheel3;

    private bool interacting = false;

    private void Awake()
    {
        wheel1 = wheelParent.GetChild(0);
        wheel2 = wheelParent.GetChild(1);
        wheel3 = wheelParent.GetChild(2);
        animator = GetComponent<Animator>();
        ToggleCanBeInteractedWith();
    }

    public void PowerUp()
    {
        // turn on lights
        LightsParent.gameObject.SetActive(true);
        ToggleCanBeInteractedWith();
    }

    public override void Activate()
    {
        // spin the wheel
        if (player.HasFirstCoin)
        {
            ToggleCutCam();
            Decide();
            ToggleCanBeInteractedWith();
            player.ClearInteraction();
            animator.SetBool("PullLever", true);
            SetInteractiveIcon(false);
        }
        else
            Debug.Log("Need Initial Coin");
    }

    private void Decide()
    {
        int rand = Random.Range(0, 10);
        if (rand > 5)
        {
            StartCoroutine(RotateWheels(235, 235, 235, 3));
        }
        if (rand > 2)
        {
            StartCoroutine(RotateWheels(265, 265, 0, 2));
        }
        else
        {
            StartCoroutine(RotateWheels(0, 295, 70, 1));
        }
    }


    private IEnumerator RotateWheels(float wheel1Rotation, float wheel2Rotation, float wheel3Rotation, int outcome)
    {
        float spinSpeed = 360;
        bool done1 = false;
        bool done2 = false;
        bool done3 = false;
        yield return new WaitForSeconds(0.8333f);
        float startTime = Time.time;

        // start the rotation
        while (Time.time - startTime < 2)
        {
            wheel1.Rotate(new Vector3(spinSpeed * Time.deltaTime, 0, 0));
            if (Time.time - startTime > 0.5f)
                wheel2.Rotate(new Vector3(spinSpeed * Time.deltaTime, 0, 0));
            if (Time.time - startTime > 1f)
                wheel3.Rotate(new Vector3(spinSpeed * Time.deltaTime, 0, 0));

            yield return new WaitForEndOfFrame();
        }
        startTime = Time.time;
        while (Time.time - startTime < 2)
        {
            wheel1.Rotate(new Vector3(spinSpeed * Time.deltaTime, 0, 0));
            wheel2.Rotate(new Vector3(spinSpeed * Time.deltaTime, 0, 0));
            wheel3.Rotate(new Vector3(spinSpeed * Time.deltaTime, 0, 0));

            yield return new WaitForEndOfFrame();
        }
        startTime = Time.time;
        while (!done1 || !done2 || !done3)
        {
            if (Time.time - startTime > 2 && !done1)
            {
                wheel1.localRotation = Quaternion.Euler(wheel1Rotation, 0, 0);
                done1 = true;
            }

            if (Time.time - startTime > 3 && done1 && !done2)
            {
                wheel2.localRotation = Quaternion.Euler(wheel2Rotation, wheel2.rotation.y, 0);
                done2 = true;
            }

            if (Time.time - startTime > 4 && done2 && !done3)
            {
                wheel3.localRotation = Quaternion.Euler(wheel3Rotation, 0, 0);
                done3 = true;
            }

            if (!done1)
                wheel1.Rotate(new Vector3(spinSpeed * Time.deltaTime, 0, 0));

            if (!done2)
                wheel2.Rotate(new Vector3(spinSpeed * Time.deltaTime, 0, 0));

            if (!done3)
                wheel3.Rotate(new Vector3(spinSpeed * Time.deltaTime, 0, 0));
            yield return new WaitForEndOfFrame();
        }
        PlayerInventory.Instance.addCopperCoins(outcome);
        PlayerInventory.Instance.addSilverCoins(outcome);
        PlayerInventory.Instance.addGoldCoins(outcome);
        yield return new WaitForSecondsRealtime(1);
        ToggleCutCam();
    }

    public void ToggleCutCam()
    {
        interacting = !interacting;
        CutCam.position = CamPos.transform.position;
        CutCam.rotation = CamPos.transform.rotation;
        CutCam.gameObject.SetActive(interacting);
        player.GetComponent<FirstPersonController>().ToggleMovement();
    }
}
