using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class UIMoves : MonoBehaviour
{
    [SerializeField] private Color32 EmptyColor;
    [SerializeField] private Color32 Empty2Color;
    [SerializeField] private Color32 BaseColor;
    [SerializeField] private Color32 Base2Color;
    [SerializeField] private Color32 clickedColor;

    [SerializeField] private Sprite[] pieces;
    [SerializeField] private GameObject player;

    public TextMeshProUGUI[] MoveCount;
    public int[] moveCounter;
    [SerializeField] public GameObject[] MoveCountBg;
    [SerializeField] private TextMeshProUGUI[] NamePieces;
    private int SelectedPiece=0;

    /*
    0 == king
    1 == pawn
    2 == knight
    3 == rock
    4 == bishop
    5 == queen   
    */

    /*private void Start()
    {
        moveCounter[0] = 0;
        MoveCount[0].text = "x"+moveCounter[0].ToString();
        moveCounter[1] = 0;
        MoveCount[1].text = "x" + moveCounter[1].ToString();
        moveCounter[2] = 1;
        MoveCount[2].text = "x" + moveCounter[2].ToString();
        moveCounter[3] = 0;
        MoveCount[3].text = "x" + moveCounter[3].ToString();
        moveCounter[4] = 0;
        MoveCount[4].text = "x" + moveCounter[4].ToString();
        moveCounter[5] = 5;
        MoveCount[5].text = "x" + moveCounter[5].ToString();
    }*/

    public void CheckCount(int MoveCounterId)
    {
        if (FindObjectOfType<AudioManager>() != null)
            FindObjectOfType<AudioManager>().Play("select");
        if (moveCounter[MoveCounterId]>0)
        {
            if (MoveCounterId==0)
            {
                foreach (GameObject g in MoveCountBg) g.GetComponent<Image>().color = EmptyColor;
                MoveCountBg[MoveCounterId].GetComponent<Image>().color = clickedColor;
                GetComponent<movement>().ClearMove();
                GetComponent<movement>().ShowMoveClickKing();
                SelectedPiece = 0;
            }
            if (MoveCounterId ==1)
            {
                foreach (GameObject g in MoveCountBg) g.GetComponent<Image>().color = EmptyColor;
                MoveCountBg[MoveCounterId].GetComponent<Image>().color = clickedColor;
                GetComponent<movement>().ClearMove();
                GetComponent<movement>().ShowMoveClickPawn();
                SelectedPiece = 1;
            }
            if (MoveCounterId ==2)
            {
                foreach (GameObject g in MoveCountBg) g.GetComponent<Image>().color = EmptyColor;
                MoveCountBg[MoveCounterId].GetComponent<Image>().color = clickedColor;
                GetComponent<movement>().ClearMove();
                GetComponent<movement>().ShowMoveClickKnight();
                SelectedPiece = 2;
            }
            if (MoveCounterId ==3)
            {
                foreach (GameObject g in MoveCountBg) g.GetComponent<Image>().color = EmptyColor;
                MoveCountBg[MoveCounterId].GetComponent<Image>().color = clickedColor;
                GetComponent<movement>().ClearMove();
                GetComponent<movement>().ShowMoveClickRock();
                SelectedPiece = 3;
            }
            if (MoveCounterId ==4)
            {
                foreach (GameObject g in MoveCountBg) g.GetComponent<Image>().color = EmptyColor;
                MoveCountBg[MoveCounterId].GetComponent<Image>().color = clickedColor;
                GetComponent<movement>().ClearMove();
                GetComponent<movement>().ShowMoveClickBishop();
                SelectedPiece = 4;
            }
            if (MoveCounterId ==5)
            {
                foreach (GameObject g in MoveCountBg) g.GetComponent<Image>().color = EmptyColor;
                MoveCountBg[MoveCounterId].GetComponent<Image>().color = clickedColor;
                GetComponent<movement>().ClearMove();
                GetComponent<movement>().ShowMoveClickQueen();
                SelectedPiece = 5;
            }
        }
    }

    public void unselect()
    {
        foreach(GameObject g in MoveCountBg) g.GetComponent<Image>().color = EmptyColor;
    }

    public void DecreseMove()
    {
        moveCounter[SelectedPiece]--;
        MoveCount[SelectedPiece].text = "x" + moveCounter[SelectedPiece].ToString();
    }

    private void Update()
    {
        for(int i=0; i<6; i++)
        {
            if (moveCounter[i]<=0 && MoveCountBg[i].GetComponent<Image>().color != EmptyColor)
            {
                MoveCountBg[i].GetComponent<Image>().color = EmptyColor;
                MoveCount[i].color = Empty2Color;
                NamePieces[i].color = Empty2Color;
                MoveCountBg[i].GetComponent<Button>().interactable = false;
            }
        }

        for (int i = 0; i < 6; i++)
        {
            if (moveCounter[i] > 0 && MoveCountBg[i].GetComponent<Image>().color == EmptyColor)
            {
                MoveCountBg[i].GetComponent<Image>().color = Color.white;
                MoveCount[i].color = Base2Color;
                NamePieces[i].color = Base2Color;
                MoveCountBg[i].GetComponent<Button>().interactable = true;
            }
        }

        for(int i=0; i<6; i++)
            if (SelectedPiece == i) player.GetComponent<SpriteRenderer>().sprite = pieces[i];
    }
}
