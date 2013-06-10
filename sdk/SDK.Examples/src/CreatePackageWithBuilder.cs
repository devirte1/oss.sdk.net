using System;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
	public class CreatePackageWithBuilder
	{
		public static string apiToken = "Q2xubnp5Y2dIQ3lROnNlY3JldA==";
		public static string baseUrl = "http://localhost:8080";

		public static void Main (string[] args)
		{
			// Create new esl client with api token and base url
			EslClient client = new EslClient (apiToken, baseUrl);

			//Signer firstname, lastname, email, title, company
			DocumentPackage package = PackageBuilder.NewPackageNamed ("C# Package " + DateTime.Now)
					.DescribedAs ("This is a new package")
					.WithSigner(SignerBuilder.NewSignerWithEmail("etienne_hardy@silanis.com")
					            .WithFirstName("John")
					            .WithLastName("Smith")
					            .ChallengedWithQuestions(ChallengeBuilder
					                         .FirstQuestion ("What's your favorite sport?")
					                         .Answer ("golf")
					                         .SecondQuestion ("What's your dog's name")
					                         .Answer ("Rex")))
					.Build ();

			PackageId id = client.CreatePackage (package);

			Console.WriteLine ("Package {0} was created", id.Id);
		}
	}
}