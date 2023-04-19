using System.Text;
using static System.Formats.Asn1.AsnWriter;

namespace LabMiAu.Common
{
    /// <summary>
    /// Хелпер
    /// </summary>
    public static class GoogleApiHelper
    {
        public static string ApplicationName = "Google Api AspNetCoreMVC Web Client";

        public static string ClientId = "190548042840-k652p5ge1at9dnpch2mheqdnqnqs5bc5.apps.googleusercontent.com";

        public static string ClientSecret = "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";

        public static string RedirectUri = "https://localhost:7214/Home/OauthCallback";

        public static string OauthUri = "https://accounts.google.com/o/oauth2/auth?";

        public static string Scopes = "https://www.googleapis.com/auth/userinfo.email";
        public static string State = "5d0d361f-6abd-4222-8a9a-6d41852064b8";
        public static string GetOauthUri()
        {
            StringBuilder sbUri = new StringBuilder(OauthUri);
            sbUri.Append("client_id=" + ClientId);
            sbUri.Append("&redirect_uri=" + RedirectUri);
            sbUri.Append("&response_type=" + "code");
            sbUri.Append("&scope=" + Scopes);
            sbUri.Append("&access_type=" + "offline");
            sbUri.Append("&state=" + State);

            return sbUri.ToString();
        }
    }
}
