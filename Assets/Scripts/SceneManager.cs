using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour
{
    [SerializeField]
    private float waitTime = 0.25f;
    [SerializeField]
    private GameObject letter;  // Upper scrolltext
    [SerializeField]
    private GameObject letter2; // Bottom scrolltext
    [SerializeField]
    private GameObject letter3; // For the typewriter effect
    [SerializeField]
    private Sprite[] characters;

    private float firstYpos = 0.6f;
    private float secondYpos = -0.6f;

    private float timer;
    private GameObject myChar;
    private GameObject MyUpsideChar;
    private int whatChar;
    private int charCounter;
    private static string message = "    hello world      check out the description below for the github link if you want the code      enjoy   ";
    private readonly char[] messageChars = message.ToCharArray();

    // Typewriter
    private float charSize = 0.3f;
    private float lineSpacing = 0.5f;   // First line start at -2.6
    private char[] printChars;
    string[,] data = new string[,]
    {
        {"music", "by", "joshuaempyree"},
        {"graphics", "by", "a magic unicorn"},
        {"code", "by", "it just appeared here"}
    };
    int dataLines;
    int dataWords;

    private void Start()
    {
        StartCoroutine(TypeWriter());
    }

    void Update()
    {
        SineText();
    }

    int SelectChar(char selChar)    // convert from char to "ascii code" as integer
    {
        return selChar - 97;    // a has ascii code 97 and our spritesheet starts at 0
    }

    IEnumerator TypeWriter()
    {
        float startingPoint;
        GameObject spriteChar;
        int stupidChar;
        float startLine = -2.6f;

        dataLines = data.GetLength(0);
        dataWords = data.GetLength(1);

        yield return new WaitForSeconds(1f);

        while (true)
        {
            for (int y = 0; y < dataLines; y++)
            {
                for (int i = 0; i < dataWords; i++)
                {
                    printChars = data[y, i].ToCharArray();  // Convert string to char array
                    startingPoint = ((data[y, i].Length * charSize) / 2) * -1;  // Find the starting point
                    foreach (char oneChar in printChars)
                    {
                        stupidChar = SelectChar(oneChar);
                        if (stupidChar >= 0 && stupidChar <= 26)
                        {
                            spriteChar = Instantiate(letter3, new Vector3(startingPoint, startLine, 0f), Quaternion.identity);
                            spriteChar.GetComponent<SpriteRenderer>().sprite = characters[stupidChar];  // Select correct char to display
                            yield return new WaitForSeconds(.2f);
                        }
                        startingPoint += charSize;
                    }
                    startLine -= lineSpacing;
                }
                startLine = -2.6f;  // Reset the start line after each block of text
                yield return new WaitForSeconds(5.5f);
            }
        }
    }

    void SineText()
    {
        timer += Time.deltaTime;
        if (timer >= waitTime && charCounter < message.Length)
        {
            whatChar = SelectChar(messageChars[charCounter]);
            if (whatChar >= 0 && whatChar <= 26)    // Only accept a to z in lower capital
            {
                myChar = Instantiate(letter, new Vector3(9f, firstYpos, 0f), Quaternion.identity); // X=9, Y=-0.25
                myChar.GetComponent<SpriteRenderer>().sprite = characters[whatChar];    // Select image for the sprite
                MyUpsideChar = Instantiate(letter2, new Vector3(9f, secondYpos, 0f), Quaternion.identity);
                MyUpsideChar.GetComponent<SpriteRenderer>().sprite = characters[whatChar];
            }
            charCounter++;
            timer = 0f;
        }
        else if (charCounter >= message.Length)   // If end of string, restart
        {
            charCounter = 0;
        }
    }

}
