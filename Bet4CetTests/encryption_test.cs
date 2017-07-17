using Microsoft.VisualStudio.TestTools.UnitTesting;
using b4c_classes;

namespace Bet4CetTests
{
	[TestClass]
	public class EncriptacaoTests
	{
		[TestMethod]

		public void ValidateMD5()
		{

        // Verifica se o método de encriptação está a retornar os valores esperados.

			Assert.AreEqual("698dc19d489c4e4db73e28a713eab07b", security_b4c_md5.StringToMD5("teste"));
			Assert.AreNotEqual("698dc19d489c4e4db73e28a713eab07b", security_b4c_md5.StringToMD5("cinel"));
			Assert.AreEqual("a2d7f588f571bc944da26d4c78a05c50", security_b4c_md5.StringToMD5("c1nel"));
			Assert.AreEqual("f38af96cffd3270b0d3321519e69a9cb", security_b4c_md5.StringToMD5("lisb0a"));
			Assert.AreEqual("60474c9c10d7142b7508ce7a50acf414", security_b4c_md5.StringToMD5("test12"));
			Assert.AreNotEqual("a2d7f588f571bc944da26d4c78a05c50", security_b4c_md5.StringToMD5("aposbet"));
			Assert.AreEqual("251b353b3de7e9687bd684126e991b68", security_b4c_md5.StringToMD5("cetcinel"));
			Assert.AreEqual("a7129fecd5da43e042c4302fb3d735b9", security_b4c_md5.StringToMD5("bet4cet"));

		}
	}
}