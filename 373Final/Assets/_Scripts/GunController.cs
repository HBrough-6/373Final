using System.Collections;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunController : MonoBehaviour
{
    [SerializeField] private GameObject gun;
    [SerializeField] private Animator gunAnimator;
    [SerializeField] private Animator aimAnimator;
    [SerializeField] private GameObject BulletHole;

    private bool canShoot = true;
    [SerializeField] float timeBetweenShots = 0.15f;
    [SerializeField] float bulletDissappearDelay = 3;


    [SerializeField] private CinemachineVirtualCamera cmCamera;

    private bool equipped = true;

    public float easeOutMod = 1.25f;
    public float recoilAmt = 10;
    public float dtMod = 1.25f;
    public float dtMod2 = 1.25f;


    private Coroutine returningToPos;

    public void Shoot(InputAction.CallbackContext context)
    {
        if (canShoot && equipped && context.started)
        {
            // play shooting animation
            if (gunAnimator.GetBool("Shoot"))
            {
                gunAnimator.SetBool("Again", true);
            }
            else
            {
                gunAnimator.SetBool("Shoot", true);
            }

            // shoot a ray from the middle of the camera
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("ShootableEmblem"))
                {
                    Destroy(hit.collider.gameObject);
                    PlayerInventory.Instance.IncreaseScore(100);
                }
                else if (hit.collider.CompareTag("FirstCoinShootable"))
                {
                    Destroy(hit.collider.gameObject);
                    PlayerInteraction.Instance.GainFirstCoin();
                }
                else
                {
                    GameObject bulletHoleTemp = Instantiate(BulletHole, hit.point, Quaternion.identity);

                    // set the bullet decal to look at the point it hit
                    bulletHoleTemp.transform.forward = -hit.normal;

                    StartCoroutine(DestroyBulletHole(bulletHoleTemp));
                }
            }
            // start the shooting delay
            StartCoroutine(Recoil());
            StartCoroutine(ShootDelay());
        }
    }

    public void ToggleGun(InputAction.CallbackContext context)
    {
        // when the button is pushed
        if (context.started)
        {
            // if the weapon is currently equipped
            if (equipped)
            {
                // stow the weapon
                gunAnimator.SetBool("Equip", false);
                // stop aiming down sights
                aimAnimator.SetBool("Aim", false);
            }
            // if the weapon is currently stowed
            else
            {
                // equip the weapon
                gunAnimator.SetBool("Equip", true);
            }
            equipped = !equipped;
        }
    }

    public void Aim(InputAction.CallbackContext context)
    {
        if (equipped)
        {
            if (context.started)
            {
                // aim down sights
                aimAnimator.SetBool("Aim", true);
            }
            else if (context.canceled)
            {
                // go to hipfire
                aimAnimator.SetBool("Aim", false);
            }
        }
    }

    private IEnumerator ShootDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    private IEnumerator DestroyBulletHole(GameObject bulletHoleObject)
    {
        yield return new WaitForSeconds(bulletDissappearDelay);
        Destroy(bulletHoleObject);
    }

    private IEnumerator Recoil()
    {
        if (returningToPos != null)
            StopCoroutine(returningToPos);
        CinemachinePOV temp = cmCamera.GetCinemachineComponent<CinemachinePOV>();
        float easeOutVal = 1;
        float currentRecoil = recoilAmt;
        while (currentRecoil > 9.5f)
        {
            easeOutVal = Mathf.Lerp(easeOutVal, 0, Time.deltaTime * dtMod);
            currentRecoil = Mathf.Lerp(currentRecoil * (easeOutVal * easeOutMod), 0, Time.deltaTime);

            temp.m_VerticalAxis.Value -= currentRecoil * Time.deltaTime;

            yield return new WaitForEndOfFrame();

        }
        StartCoroutine(GoDown());
    }
    private IEnumerator GoDown()
    {
        CinemachinePOV temp = cmCamera.GetCinemachineComponent<CinemachinePOV>();
        float easeOutVal = 1;
        float currentRecoil = recoilAmt;
        for (float i = 0; i < 2; i += Time.deltaTime)
        {
            easeOutVal = Mathf.Lerp(easeOutVal, 0, Time.deltaTime * dtMod2);
            currentRecoil = Mathf.Lerp(currentRecoil * (easeOutVal * easeOutMod), 0, Time.deltaTime);

            temp.m_VerticalAxis.Value += currentRecoil * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

    public void EnableGun()
    {
        transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
    }
}

