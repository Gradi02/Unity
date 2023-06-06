using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class tutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject tutMenu;
    private string info1 = "Welcome to CheZle! Its Chess-Puzzle game where your only goal is to reach the Golden Final Tile with Chess Pieces!";
    private string info2 = "On the left you can pick piece you want to move and then choose the highlighted tile to make move!";
    private string info3 = "If you make a mistake, you can restart level and try again, or watch an ads to get a hint!";
    private string info4 = "The Hint will highlights the tiles for your first moves, but remember that every level can be completed by many ways!"; 
    private string info5 = "When the tile is locked, you must to get a key to unlock the path, but firstly make sure that the key is really needed!";
    private string info6 = "The Quantum Tiles always comes in a pair. Two of the same color are in the SuperPosition.";
    private string info7 = "It means that when you stand on one of them, then you are standing on both at the same time!";


    [SerializeField] private TextMeshProUGUI info1_text;
    private int tutorialPage = 0;
    private int i = 0;
    void Start()
    {
        tutMenu.SetActive(false);
        tutMenu.SetActive(true);
    }

    private void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name == "level1")
        {
            if (tutorialPage == 0 && i < info1.Length) info1_text.text += info1[i++].ToString();
            if (tutorialPage == 1 && i < info2.Length) info1_text.text += info2[i++].ToString();
            if (tutorialPage == 2 && i < info3.Length) info1_text.text += info3[i++].ToString();
            if (tutorialPage == 3 && i < info4.Length) info1_text.text += info4[i++].ToString();
            if (tutorialPage >= 4) tutMenu.SetActive(false);
        }

        if (SceneManager.GetActiveScene().name == "level25")
        {
            if (tutorialPage == 0 && i < info5.Length) info1_text.text += info5[i++].ToString();
            if (tutorialPage >= 1) tutMenu.SetActive(false);
        }

        if (SceneManager.GetActiveScene().name == "level49")
        {
            if (tutorialPage == 0 && i < info6.Length) info1_text.text += info6[i++].ToString();
            if (tutorialPage == 1 && i < info7.Length) info1_text.text += info7[i++].ToString();
            if (tutorialPage >= 2) tutMenu.SetActive(false);
        }
    }

    public void NextPage()
    {
        //FindObjectOfType<AudioManager>().Play("click");
        tutorialPage++;
        info1_text.text = "";
        i = 0;
    }
}
