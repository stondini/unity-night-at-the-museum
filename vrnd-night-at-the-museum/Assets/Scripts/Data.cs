﻿using System.Collections;
using System.Collections.Generic;

public class Data {

	public static readonly int TYPE_MOUNTAIN = 1;

	public static readonly int TYPE_CITY = 2;

	public static readonly int TYPE_ATTRACTION = 3;

	public static readonly int TYPE_PICTURE = 4;

	public static readonly int MEDIA_TYPE_WEBPAGE = 1;

	public static readonly int MEDIA_TYPE_VIDEO = 2;

	public static readonly int MEDIA_TYPE_PICTURE = 2;

	private static readonly Data MATTERHORN = new Data(TYPE_MOUNTAIN, -1.5f, 0.8f, 2.5f, "Matterhorn", "4478m", MEDIA_TYPE_WEBPAGE, "https://en.wikipedia.org/wiki/Matterhorn");

	private static readonly Data EIGER = new Data(TYPE_MOUNTAIN, -4.157f, 0.8f, -4.24f, "Eiger", "3967m", MEDIA_TYPE_WEBPAGE, "https://en.wikipedia.org/wiki/Eiger");
    
	private static readonly Data MONCH = new Data(TYPE_MOUNTAIN, -4.09f, 0.8f, -3.963f, "Mönch", "4101m", MEDIA_TYPE_WEBPAGE, "https://en.wikipedia.org/wiki/M%C3%B6nch");

	private static readonly Data JUNGFRAU = new Data(TYPE_MOUNTAIN, -3.857f, 0.8f, -3.746f, "Jungfrau", "4158m", MEDIA_TYPE_WEBPAGE, "https://en.wikipedia.org/wiki/Jungfrau");

	private static readonly Data DOM = new Data(TYPE_MOUNTAIN, -3.068f, 0.85f, 1.17f, "Dom", "4545m", MEDIA_TYPE_WEBPAGE, "https://en.wikipedia.org/wiki/Dom_(mountain)");

	private static readonly Data DENTS_DU_MIDI = new Data(TYPE_MOUNTAIN, 4.12f, 0.7f, 0.42f, "Dents du Midi", "3257m", MEDIA_TYPE_WEBPAGE, "https://en.wikipedia.org/wiki/Dents_du_Midi");

	private static readonly Data MONT_BLANC = new Data(TYPE_MOUNTAIN, 3.82f, 0.8f, 2.957f, "Mont Blanc", "4808m", MEDIA_TYPE_WEBPAGE, "https://en.wikipedia.org/wiki/Mont_Blanc");

	private static readonly Data GRAND_COMBIN = new Data(TYPE_MOUNTAIN, 1.26f, 0.8f, 3.017f, "Grand Combin", "4314m", MEDIA_TYPE_WEBPAGE, "https://en.wikipedia.org/wiki/Grand_Combin");

	private static readonly Data WILDHORN = new Data(TYPE_MOUNTAIN, 0.76f, 0.7f, -1.748f, "Wildhorn", "3248m", MEDIA_TYPE_WEBPAGE, "https://en.wikipedia.org/wiki/Wildhorn");

	private static readonly Data ROCHERS_DE_NAYE = new Data(TYPE_MOUNTAIN, 2.665f, 0.5f, -3.89f, "Rochers de Naye", "2042m", MEDIA_TYPE_WEBPAGE, "https://en.wikipedia.org/wiki/Rochers_de_Naye");

    // <iframe width = "560" height="315" src="https://www.youtube.com/embed/siFb-AoZqb8" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>
	//private static readonly Data SION = new Data(TYPE_CITY, 0.96f, 0.32f, -0.27f, "Sion", "City & Castle", MEDIA_TYPE_VIDEO, "Video-Sion.mp4");
	private static readonly Data SION = new Data(TYPE_CITY, 1.4f, 0.45f, -0.27f, "Sion", "City & Castle", MEDIA_TYPE_VIDEO, "Media/Video-Sion");

    public static readonly Data[] MOUNTAINS = new Data[] { 
        MATTERHORN, 
        EIGER, 
        MONCH, 
        JUNGFRAU, 
        DOM, 
        DENTS_DU_MIDI, 
        MONT_BLANC, 
        GRAND_COMBIN,
        // WILDHORN,
        ROCHERS_DE_NAYE,
        SION
    };

	public readonly int type;

    public readonly float x;

    public readonly float y;

    public readonly float z;

    public readonly string name;

    public readonly string shortInfo;

    public readonly string contentURL;

	public readonly int mediaType;

	public Data(int type, float x, float y, float z, string name, string shortInfo, int mediaType, string contentURL) {
		this.type = type;
        this.x = x;
        this.y = y;
        this.z = z;
        this.name = name;
		this.shortInfo = shortInfo;
		this.mediaType = mediaType;
		this.contentURL = contentURL;
    }

    public override string ToString() {
		return string.Format("{0}:({1:f},{2:f},{3:f}:type={4}:media={5}:content={6})", this.name, this.x, this.y, this.z, this.type, this.mediaType, this.contentURL);
    }
}
