package md5769491e02af890c97b21049d387b8ceb;


public class Timer
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("iPartnerApp.Droid.Timer, iPartnerApp.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Timer.class, __md_methods);
	}


	public Timer () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Timer.class)
			mono.android.TypeManager.Activate ("iPartnerApp.Droid.Timer, iPartnerApp.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
