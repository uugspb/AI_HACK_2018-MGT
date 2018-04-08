public class TrapInfo {
    public int trapID;
    public int fishKills;
    public float probability;

    public TrapInfo(int trapID, float probability)
    {
        this.trapID = trapID;
        this.fishKills = 0;
        this.probability = probability;
    }
}
