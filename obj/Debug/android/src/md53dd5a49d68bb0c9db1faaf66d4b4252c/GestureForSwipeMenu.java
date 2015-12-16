package md53dd5a49d68bb0c9db1faaf66d4b4252c;


public class GestureForSwipeMenu
	extends android.view.GestureDetector.SimpleOnGestureListener
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onDown:(Landroid/view/MotionEvent;)Z:GetOnDown_Landroid_view_MotionEvent_Handler\n" +
			"";
		mono.android.Runtime.register ("AndroidGesture.GestureForSwipeMenu, AndroidGesture, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", GestureForSwipeMenu.class, __md_methods);
	}


	public GestureForSwipeMenu () throws java.lang.Throwable
	{
		super ();
		if (getClass () == GestureForSwipeMenu.class)
			mono.android.TypeManager.Activate ("AndroidGesture.GestureForSwipeMenu, AndroidGesture, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public GestureForSwipeMenu (android.widget.ListView p0) throws java.lang.Throwable
	{
		super ();
		if (getClass () == GestureForSwipeMenu.class)
			mono.android.TypeManager.Activate ("AndroidGesture.GestureForSwipeMenu, AndroidGesture, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Widget.ListView, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public boolean onDown (android.view.MotionEvent p0)
	{
		return n_onDown (p0);
	}

	private native boolean n_onDown (android.view.MotionEvent p0);

	java.util.ArrayList refList;
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
