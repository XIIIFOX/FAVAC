package md5d3060196ed1645b423bcfbd4fdd52cef;


public class FAVAC_WebViewRenderer_FAVAC_WebViewClient
	extends android.webkit.WebViewClient
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onPageFinished:(Landroid/webkit/WebView;Ljava/lang/String;)V:GetOnPageFinished_Landroid_webkit_WebView_Ljava_lang_String_Handler\n" +
			"n_onPageStarted:(Landroid/webkit/WebView;Ljava/lang/String;Landroid/graphics/Bitmap;)V:GetOnPageStarted_Landroid_webkit_WebView_Ljava_lang_String_Landroid_graphics_Bitmap_Handler\n" +
			"";
		mono.android.Runtime.register ("FAVAC.Droid.FAVAC_WebViewRenderer+FAVAC_WebViewClient, FAVAC.Android", FAVAC_WebViewRenderer_FAVAC_WebViewClient.class, __md_methods);
	}


	public FAVAC_WebViewRenderer_FAVAC_WebViewClient ()
	{
		super ();
		if (getClass () == FAVAC_WebViewRenderer_FAVAC_WebViewClient.class)
			mono.android.TypeManager.Activate ("FAVAC.Droid.FAVAC_WebViewRenderer+FAVAC_WebViewClient, FAVAC.Android", "", this, new java.lang.Object[] {  });
	}

	public FAVAC_WebViewRenderer_FAVAC_WebViewClient (md5d3060196ed1645b423bcfbd4fdd52cef.FAVAC_WebViewRenderer p0)
	{
		super ();
		if (getClass () == FAVAC_WebViewRenderer_FAVAC_WebViewClient.class)
			mono.android.TypeManager.Activate ("FAVAC.Droid.FAVAC_WebViewRenderer+FAVAC_WebViewClient, FAVAC.Android", "FAVAC.Droid.FAVAC_WebViewRenderer, FAVAC.Android", this, new java.lang.Object[] { p0 });
	}


	public void onPageFinished (android.webkit.WebView p0, java.lang.String p1)
	{
		n_onPageFinished (p0, p1);
	}

	private native void n_onPageFinished (android.webkit.WebView p0, java.lang.String p1);


	public void onPageStarted (android.webkit.WebView p0, java.lang.String p1, android.graphics.Bitmap p2)
	{
		n_onPageStarted (p0, p1, p2);
	}

	private native void n_onPageStarted (android.webkit.WebView p0, java.lang.String p1, android.graphics.Bitmap p2);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
