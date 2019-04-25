using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    public Sprite bgImage;
    public Sprite[] puzzles;
    public List<Sprite> gamePuzzles = new List<Sprite>();
    private bool firstGuess, secondGuess;
    private int countGuesses;
    private int countCorrectGuesses;
        private int gameGuesses;
    private string firstGuessPuzzle, secondGuessPuzzle;
    private int firstGuessIndex, secondGuessIndex;

    public List<Button> btns = new List<Button>();

    void Start()
    {
        GetButtons();
        AddListeners();
        AddGamePuzzles();
        Shuffle(gamePuzzles);
        gameGuesses = gamePuzzles.Count / 2;
    }

   
    void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");
        for(int i=0;i<objects.Length; i++)
        {
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = bgImage;
        }

        
    }
    void AddGamePuzzles()
    {
        int looper = btns.Count;
        int index = 0;
        for(int i = 0; i < looper; i++)
        {
            if (index == looper / 2)
            {
                index = 0;
            }
            gamePuzzles.Add(puzzles[index]);
            index++;
        }
    }
    void AddListeners()
    {
        foreach (Button btn in btns)
        {
            btn.onClick.AddListener(() => PickAPuzzle());
        }
    }
    public void PickAPuzzle()
    {
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        if (!firstGuess)
        {
            firstGuess = true;
            firstGuessIndex = int.Parse(name);
            firstGuessPuzzle = gamePuzzles[firstGuessIndex].name;
            btns[firstGuessIndex].image.sprite = gamePuzzles[firstGuessIndex];
        }
        else if (!secondGuess && (firstGuessIndex != int.Parse(name)))
        {
            secondGuess = true;
            secondGuessIndex = int.Parse(name);
            secondGuessPuzzle = gamePuzzles[secondGuessIndex].name;
            btns[secondGuessIndex].image.sprite = gamePuzzles[secondGuessIndex];
        }
        else if (secondGuess && firstGuess)
        {
            if (firstGuessPuzzle == secondGuessPuzzle)
            {
                btns[firstGuessIndex].image.color = new Color(0, 0, 0, 0);
                btns[secondGuessIndex].image.color = new Color(0, 0, 0, 0);
                btns[firstGuessIndex].interactable = false;
                btns[secondGuessIndex].interactable = false;
                CheckIfTheGameIsFinished();
            }
            else
            {
                btns[firstGuessIndex].image.sprite = bgImage;
                btns[secondGuessIndex].image.sprite = bgImage;
            }
            firstGuess = secondGuess = false;
        }
    }

    void CheckIfTheGameIsFinished()
    {
        countCorrectGuesses++;
        if (countCorrectGuesses == gameGuesses)
        {
            SceneManager.LoadScene(3);
        }
    }
    
    void Shuffle(List<Sprite> list)
    {
        for(int i = 0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIndex = Random.Range(0, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
    
}
