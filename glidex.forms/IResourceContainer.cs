using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Android.Glide
{
	public interface IResourceContainer
	{
		#region Public Methods

		int GetDrawable (string fileName);

		#endregion Public Methods
	}
}
