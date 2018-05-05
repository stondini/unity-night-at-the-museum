using System.Collections;
using System.Collections.Generic;

public class MountainData {

    private static readonly MountainData MATTERHORN = new MountainData(-1.5f, 0.8f, 2.5f, "Matterhorn", 4478, "https://en.wikipedia.org/wiki/Matterhorn");

    private static readonly MountainData EIGER = new MountainData(-4.157f, 0.8f, -4.24f, "Eiger", 3967, "https://en.wikipedia.org/wiki/Eiger");

    private static readonly MountainData MONCH = new MountainData(-4.09f, 0.8f, -3.963f, "Mönch", 4101, "https://en.wikipedia.org/wiki/M%C3%B6nch");

    private static readonly MountainData JUNGFRAU = new MountainData(-3.857f, 0.8f, -3.746f, "Jungfrau", 4158, "https://en.wikipedia.org/wiki/Jungfrau");

    private static readonly MountainData DOM = new MountainData(-3.068f, 0.85f, 1.17f, "Dom", 4545, "https://en.wikipedia.org/wiki/Dom_(mountain)");

    private static readonly MountainData DENTS_DU_MIDI = new MountainData(4.12f, 0.7f, 0.42f, "Dents du Midi", 3257, "https://en.wikipedia.org/wiki/Dents_du_Midi");

    private static readonly MountainData MONT_BLANC = new MountainData(3.82f, 0.8f, 2.957f, "Mont Blanc", 4808, "https://en.wikipedia.org/wiki/Mont_Blanc");

    private static readonly MountainData GRAND_COMBIN = new MountainData(1.26f, 0.8f, 3.017f, "Grand Combin", 4314, "https://en.wikipedia.org/wiki/Grand_Combin");

    private static readonly MountainData WILDHORN = new MountainData(0.76f, 0.7f, -1.748f, "Wildhorn", 3248, "https://en.wikipedia.org/wiki/Wildhorn");

    private static readonly MountainData ROCHERS_DE_NAYE = new MountainData(2.665f, 0.5f, -3.89f, "Rochers de Naye", 2042, "https://en.wikipedia.org/wiki/Rochers_de_Naye");

    public static readonly MountainData[] MOUNTAINS = new MountainData[] { 
        MATTERHORN, 
        EIGER, 
        MONCH, 
        JUNGFRAU, 
        DOM, 
        DENTS_DU_MIDI, 
        MONT_BLANC, 
        GRAND_COMBIN,
        WILDHORN,
        ROCHERS_DE_NAYE
    };

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
