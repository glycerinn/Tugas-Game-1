using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GateQueue : MonoBehaviour
{
    public GameObject[] fishPrefab, trashPrefab, coinPrefab;
    public Transform spawnPos;
    public int SortableCount = 10;
    public float spacing = 15f;
    private List<Sortable> Sortables_ = new List<Sortable>();
    GameObject obj;
    Sortable sortable;
    public ScoreManager scoreManager;
    public CoinManager coinManager;
    public Timer timerManager;
    private bool Busy;
    public GameOverScreen GameOverScreen;
    public Image countdownCircle;
    public AudioSource MyAudio, BGM;
    public AudioClip MySoundEffect, MySoundEffect2;
    

    void Start()
    {
        for (int i = 0; i < SortableCount; i++)
        {
            SpawnQueue(i);
        }
    }

    void Update()
    {
        if (Sortables_.Count == 0 || Busy) return;

        Sortable currentItem = Sortables_[0];

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            PlaySound();
            Vector3 targetPos = currentItem.transform.position + Vector3.up * 6;
            if (currentItem.GetSortableType() == Sortable.SortableType.Fish)
            {

                StartCoroutine(SortAndShift(currentItem, targetPos));
                scoreManager.AddScore(5);
                timerManager.restartTimer();
            }
            else if (currentItem.GetSortableType() == Sortable.SortableType.Trash)
            {
                StartCoroutine(SortAndShift(currentItem, targetPos));
                GameOver();
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector3 targetPos = currentItem.transform.position + Vector3.up * 0;
            if (currentItem.GetSortableType() == Sortable.SortableType.Coin)
            {
                StartCoroutine(SortAndShift(currentItem, targetPos));
                coinManager.AddCoin(1);
                timerManager.restartTimer();
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            PlaySound2();
            Vector3 targetPos = currentItem.transform.position + Vector3.down * 5;
            if (currentItem.GetSortableType() == Sortable.SortableType.Trash)
            {

                StartCoroutine(SortAndShift(currentItem, targetPos));
                scoreManager.AddScore(5);
                timerManager.restartTimer();
            }
            else if (currentItem.GetSortableType() == Sortable.SortableType.Fish)
            {
                StartCoroutine(SortAndShift(currentItem, targetPos));
                GameOver();
            }
        }

        if (countdownCircle.fillAmount == 0)
        {
            GameOver();
            
        }
    }

    IEnumerator SortAndShift(Sortable sortable, Vector3 targetPos)
    {
        Busy = true;

        // Animate up/down move
        while (Vector3.Distance(sortable.transform.position, targetPos) > 0.01f)
        {
            sortable.transform.position = Vector3.MoveTowards(sortable.transform.position, targetPos, 20 * Time.deltaTime);
            yield return null;
        }

        Destroy(sortable.gameObject);
        Sortables_.RemoveAt(0);

        // Shift remaining items left smoothly
        List<Vector3> targetPositions = new List<Vector3>();
        for (int i = 0; i < Sortables_.Count; i++)
        {
            targetPositions.Add(spawnPos.position + Vector3.right * (i * spacing));
        }

        bool shifting = true;
        while (shifting)
        {
            shifting = false;
            for (int i = 0; i < Sortables_.Count; i++)
            {
                Sortables_[i].transform.position = Vector3.MoveTowards(Sortables_[i].transform.position, targetPositions[i], 10 * Time.deltaTime);
                if (Vector3.Distance(Sortables_[i].transform.position, targetPositions[i]) > 0.01f)
                    shifting = true;
            }
            yield return null;
        }

        SpawnQueue(Sortables_.Count);
        Busy = false;
    }

    public void SpawnQueue(int index)
    {
        GameObject prefab;
        if (Random.value > 0.5f)
        {
            prefab = fishPrefab[Random.Range(0, fishPrefab.Length)];
        }
        else if (Random.value < 0.5f)
        {
            prefab = trashPrefab[Random.Range(0, trashPrefab.Length)];
        }
        else
        {
            prefab = coinPrefab[Random.Range(0, coinPrefab.Length)];
        }
        obj = Instantiate(prefab, spawnPos.position + Vector3.right * (index * spacing), Quaternion.identity);
        sortable = obj.GetComponent<Sortable>();
        Sortables_.Add(sortable);
    }

    public void GameOver()
    {
        coinManager.AddtoTotal();
        GameOverScreen.SetUp();
        BGM.Stop();
    }

    void PlaySound()
    {
        MyAudio.clip = MySoundEffect;
        MyAudio.Play();
    }

    void PlaySound2()
    {
        MyAudio.clip = MySoundEffect2;
        MyAudio.Play();
    }
}
