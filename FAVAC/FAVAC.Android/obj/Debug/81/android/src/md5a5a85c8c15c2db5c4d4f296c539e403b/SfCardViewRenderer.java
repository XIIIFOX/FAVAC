package md5a5a85c8c15c2db5c4d4f296c539e403b;


public class SfCardViewRenderer
	extends md533c0a8921e4153237a3ffec26b3759de.SfBorderRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onTouchEvent:(Landroid/view/MotionEvent;)Z:GetOnTouchEvent_Landroid_view_MotionEvent_Handler\n" +
			"";
		mono.android.Runtime.register ("Syncfusion.XForms.Android.Cards.SfCardViewRenderer, Syncfusion.Cards.XForms.Android", SfCardViewRenderer.class, __md_methods);
	}


	public SfCardViewRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == SfCardViewRenderer.class)
			mono.android.TypeManager.Activate ("Syncfusion.XForms.Android.Cards.SfCardViewRenderer, Syncfusion.Cards.XForms.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public SfCardViewRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == SfCardViewRenderer.class)
			mono.android.TypeManager.Activate ("Syncfusion.XForms.Android.Cards.SfCardViewRenderer, Syncfusion.Cards.XForms.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public SfCardViewRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == SfCardViewRenderer.class)
			mono.android.TypeManager.Activate ("Syncfusion.XForms.Android.Cards.SfCardViewRenderer, Syncfusion.Cards.XForms.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public boolean onTouchEvent (android.view.MotionEvent p0)
	{
		return n_onTouchEvent (p0);
	}

	private native boolean n_onTouchEvent (android.view.MotionEvent p0);

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
