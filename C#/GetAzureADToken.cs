		public static AuthenticationResult GetToken(string tenantName, string resourceUrl)
		{
			try
			{
				var authContext = new AuthenticationContext($"https://login.microsoftonline.com/{tenantName}.onmicrosoft.com");

				var appRegId = ConfigurationManager.AppSettings["AppRegId"];
				var appRegSecret = ConfigurationManager.AppSettings["AppRegSecret"];
				var credential = new ClientCredential(appRegId, appRegSecret);

				var result = authContext.AcquireTokenAsync(resourceUrl, credential).Result;
				return result;
			}
			catch (Exception)
			{
				throw;
			}
		}


		public static AuthenticationResult GetTokenForCrm(string tenantName)
		{
			try
			{
				var authContext = new AuthenticationContext($"https://login.microsoftonline.com/{tenantName}.onmicrosoft.com");

				var appRegId = ConfigurationManager.AppSettings["AppRegId"];
				var appRegSecret = ConfigurationManager.AppSettings["AppRegSecret"];
				var credential = new ClientCredential(appRegId, appRegSecret);

				var result = authContext.AcquireTokenAsync(ConfigurationManager.AppSettings["CrmResourceUrl"], credential).Result;
				return result;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public static AuthenticationResult GetTokenForCallingUser(string tenantName, string resourceUrl, string userToken, string username)
		{
			try
			{
				var authContext = new AuthenticationContext($"https://login.microsoftonline.com/{tenantName}.onmicrosoft.com");

				var appRegId = ConfigurationManager.AppSettings["AppRegId"];
				var appRegSecret = ConfigurationManager.AppSettings["AppRegSecret"];
				var credential = new ClientCredential(appRegId, appRegSecret);

				var userAssertion = new UserAssertion(userToken, "urn:ietf:params:oauth:grant-type:jwt-bearer", username);

				var result = authContext.AcquireTokenAsync(resourceUrl, credential).Result;
				return result;
			}
			catch (Exception)
			{
				throw;
			}
		}
