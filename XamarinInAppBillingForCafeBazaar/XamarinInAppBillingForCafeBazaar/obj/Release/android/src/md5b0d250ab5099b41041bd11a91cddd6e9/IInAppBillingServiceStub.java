package md5b0d250ab5099b41041bd11a91cddd6e9;


public abstract class IInAppBillingServiceStub
	extends android.os.Binder
	implements
		mono.android.IGCUserPeer,
		android.os.IInterface
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onTransact:(ILandroid/os/Parcel;Landroid/os/Parcel;I)Z:GetOnTransact_ILandroid_os_Parcel_Landroid_os_Parcel_IHandler\n" +
			"n_asBinder:()Landroid/os/IBinder;:GetAsBinderHandler:Android.OS.IInterfaceInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("Com.Android.Vending.Billing.IInAppBillingServiceStub, XamarinInAppBillingForCafeBazaar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", IInAppBillingServiceStub.class, __md_methods);
	}


	public IInAppBillingServiceStub () throws java.lang.Throwable
	{
		super ();
		if (getClass () == IInAppBillingServiceStub.class)
			mono.android.TypeManager.Activate ("Com.Android.Vending.Billing.IInAppBillingServiceStub, XamarinInAppBillingForCafeBazaar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public boolean onTransact (int p0, android.os.Parcel p1, android.os.Parcel p2, int p3)
	{
		return n_onTransact (p0, p1, p2, p3);
	}

	private native boolean n_onTransact (int p0, android.os.Parcel p1, android.os.Parcel p2, int p3);


	public android.os.IBinder asBinder ()
	{
		return n_asBinder ();
	}

	private native android.os.IBinder n_asBinder ();

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
