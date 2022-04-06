using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class onPlayerEnter : MonoBehaviour
{
    public AudioSource[] sounds;
    public AudioSource startAudio;
    public AudioSource afterCollision;
    public GameObject sphere;
    public GameObject door;
    bool triggered = false;
    float count = 16f;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && triggered == false)
        {
            triggered = true;
            door.SetActive(true);
            startAudio.Stop();
            StartCoroutine(WaitAndDoSomething());
        }
    }

    IEnumerator WaitAndDoSomething()
    {
        yield return new WaitForSeconds(2f);
        transform.Find("R1").gameObject.SetActive(true);
        transform.Find("R2").gameObject.SetActive(true);
        transform.Find("R3").gameObject.SetActive(true);
        transform.Find("R4").gameObject.SetActive(true);
        transform.Find("R5").gameObject.SetActive(true);
        transform.Find("R6").gameObject.SetActive(true);
        transform.Find("R7").gameObject.SetActive(true);
        afterCollision.Play();
        while (count >= 0)
        {
            yield return new WaitForSeconds(0.1f);
            Vector3 scale = sphere.transform.localScale;
            sphere.transform.localScale = new Vector3(scale.x + 0.001f, scale.y + 0.001f, scale.z + 0.001f);

            count -= 0.1f;
        }
        afterCollision.Stop();
        
        transform.Find("R1").gameObject.SetActive(false);
        transform.Find("R2").gameObject.SetActive(false);
        transform.Find("R3").gameObject.SetActive(false);
        transform.Find("R4").gameObject.SetActive(false);
        transform.Find("R5").gameObject.SetActive(false);
        transform.Find("R6").gameObject.SetActive(false);
        transform.Find("R7").gameObject.SetActive(false);
        sphere.SetActive(false);
        door.SetActive(false);
    }
}
