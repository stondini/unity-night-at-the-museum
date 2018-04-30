using System.Collections;
using System.Collections.Generic;

public class MountainData {

    private static readonly MountainData MATTERHORN = new MountainData(-1.5f, 1.1f, 2.48f, "Matterhorn", 4478, "https://en.wikipedia.org/wiki/Matterhorn");

    private static readonly MountainData EIGER = new MountainData(-4.20f, 1.1f, -4.24f, "Eiger", 3967, "https://en.wikipedia.org/wiki/Eiger");

    private static readonly MountainData MONCH = new MountainData(-3.95f, 1.1f, -4.08f, "Mönch", 4101, "https://en.wikipedia.org/wiki/M%C3%B6nch");

    private static readonly MountainData JUNGFRAU = new MountainData(-3.65f, 1.1f, -3.65f, "Jungfrau", 4158, "https://en.wikipedia.org/wiki/Jungfrau");

    public static readonly MountainData[] MOUNTAINS = new MountainData[] { MATTERHORN, EIGER, MONCH, JUNGFRAU};

    public readonly float x;

    public readonly float y;

    public readonly float z;

    public readonly string name;

    public readonly int altitude;

    public readonly string docURL;

    public MountainData(float x, float y, float z, string name, int altitude, string docURL) {
        this.x = x;
        this.y = y;
        this.z = z;
        this.name = name;
        this.altitude = altitude;
        this.docURL = docURL;
    }

    public override string ToString() {
        return string.Format("{0}: ({1:f},{2:f},{3:f})", this.name, this.x, this.y, this.z);
    }
}
