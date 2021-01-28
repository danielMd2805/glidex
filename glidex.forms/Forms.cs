#nullable enable

using Android.App;
using Android.OS;
using System;
using System.Reflection;
using Xamarin.Forms.Platform.Android;

namespace Android.Glide
{
	/// <summary>
	/// Class for initializing glidex.forms
	/// </summary>
	public static class Forms
	{
		#region Public Properties

		/// <summary>
		/// A flag indicating if Debug logging is enabled
		/// </summary>
		public static bool IsDebugEnabled {
			get;
			private set;
		}

		#endregion Public Properties

		/// <summary>
		/// Initializes glidex.forms, put this after your `Xamarin.Forms.Forms.Init (this, bundle);` call.
		/// </summary>
		/// <param name="debug">Enables debug logging. Turn this on to verify Glide is being used in your app.</param>
		//[Obsolete ("Use Forms.Init(Activity,bool) instead.")]
		//public static void Init (bool debug = false)
		//{
		//	Init ((Activity) Xamarin.Forms.Forms.Context, null, debug: debug);
		//}

		#region Public Methods

		/// <summary>
		/// Initializes glidex.forms, put this after your `Xamarin.Forms.Forms.Init (this, bundle);` call.
		/// </summary>
		/// <param name="activity">The MainActivity of your application.</param>
		/// <param name="handler">An implementation of IGlideHandler for customizing calls to Glide.</param>
		/// <param name="debug">Enables debug logging. Turn this on to verify Glide is being used in your app.</param>
		public static void Init (Activity activity, IResourceContainer resourceContainer, IGlideHandler? handler = default, bool debug = false)
		{
			Activity = activity;
			GlideHandler = handler;
			IsDebugEnabled = debug;
			ResourceContainer = resourceContainer;
			activity.Application?.RegisterActivityLifecycleCallbacks (lifecycle);
		}

		#endregion Public Methods

		#region Internal Properties

		internal static Activity? Activity { get; private set; }

		internal static IGlideHandler? GlideHandler { get; private set; }

		internal static IResourceContainer? ResourceContainer { get; private set; }

		#endregion Internal Properties

		#region Internal Methods

		internal static void Debug (string format, params object [] args)
		{
			if (IsDebugEnabled)
				Util.Log.Debug (Tag, format, args);
		}

		internal static void Warn (string format, params object [] args)
		{
			Util.Log.Warn (Tag, format, args);
		}

		#endregion Internal Methods

		#region Private Fields

		private const string Tag = "glidex";
		private static readonly ActivityLifecycle lifecycle = new ActivityLifecycle ();

		#endregion Private Fields

		#region Private Classes

		private class ActivityLifecycle : Java.Lang.Object, Application.IActivityLifecycleCallbacks
		{
			#region Public Methods

			public void OnActivityCreated (Activity activity, Bundle? savedInstanceState)
			{
			}

			public void OnActivityDestroyed (Activity activity)
			{
				if (Activity == activity) {
					Activity = null;
				}
			}

			public void OnActivityPaused (Activity activity)
			{
			}

			public void OnActivityResumed (Activity activity)
			{
			}

			public void OnActivitySaveInstanceState (Activity activity, Bundle outState)
			{
			}

			public void OnActivityStarted (Activity activity)
			{
			}

			public void OnActivityStopped (Activity activity)
			{
			}

			#endregion Public Methods
		}

		#endregion Private Classes
	}
}
