using System.Collections;

public class Phase
{
    public string name;
    public float timeLimit;
    public bool isLimited;

    public Phase()
    {
        name = "";
        timeLimit = -1f;    // -1f :무제한
        isLimited = false;
    }

    public Phase(string phaseName)
    {
        name = phaseName;

        if (name.Equals("Start"))
            timeLimit = 10f;
        else if (name.Equals("Ready"))
            timeLimit = 30f;
        else if (name.Equals("Battle"))
            timeLimit = -1f;
        else if (name.Equals("End"))
            timeLimit = 0f;


        if (timeLimit > 0)
            isLimited = true;
        else
            isLimited = false;
    }
}
