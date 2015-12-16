package md53dd5a49d68bb0c9db1faaf66d4b4252c;


public class ListViewHolderClass
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("AndroidGesture.ListViewHolderClass, AndroidGesture, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ListViewHolderClass.class, __md_methods);
	}


	public ListViewHolderClass () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ListViewHolderClass.class)
			mono.android.TypeManager.Activate ("AndroidGesture.ListViewHolderClass, AndroidGesture, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

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
