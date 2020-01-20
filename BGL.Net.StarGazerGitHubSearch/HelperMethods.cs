using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BGL.Net.StarGazerGitHubSearch
{
    public static class HelperMethods
    {
        public static string RemoveWhitespace(string searchUserName) => searchUserName.Replace(" ", "");

    }
}