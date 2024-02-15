using UnityEngine;

public class GunsChanger : MonoBehaviour
{
    [SerializeField] private GameObject pistol;
    [SerializeField] private GameObject guns1;
    [SerializeField] private GameObject guns2;

    private void Update()
    {
        ChangeGunOnKeyPress(KeyCode.Alpha1, pistol);
        ChangeGunOnKeyPress(KeyCode.Alpha2, guns1);
        ChangeGunOnKeyPress(KeyCode.Alpha3, guns2);
    }

    private void ChangeGunOnKeyPress(KeyCode key, GameObject gun)
    {
        if (Input.GetKeyDown(key))
        {
            pistol.SetActive(gun == pistol);
            guns1.SetActive(gun == guns1);
            guns2.SetActive(gun == guns2);
        }
    }
}
