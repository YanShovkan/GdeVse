using System;
namespace XamarinAppWhereAll.AppConstant
{
    public class Constants
    {
		public static string AppName = "XamarinApp";

		// OAuth
		// For Google login, configure at https://console.developers.google.com/
		public static string AndroidClientId = "154089692265-n097db0gtams352klfm3sv5pb6b8de4s.apps.googleusercontent.com";

		// These values do not need changing
		public static string Scope = "https://www.googleapis.com/auth/userinfo.email";
		public static string AuthorizeUrl = "https://accounts.google.com/o/oauth2/auth";
		public static string AccessTokenUrl = "https://www.googleapis.com/oauth2/v4/token";
		public static string UserInfoUrl = "https://www.googleapis.com/oauth2/v2/userinfo";

		// Set these to reversed iOS/Android client ids, with :/oauth2redirect appended
		public static string AndroidRedirectUrl = "com.googleusercontent.apps.154089692265-n097db0gtams352klfm3sv5pb6b8de4s:/oauth2redirect";
	}
}
