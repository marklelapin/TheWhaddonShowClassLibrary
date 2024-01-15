using TheWhaddonShowClassLibrary.Models;

namespace WhaddonShowClassLibrary.UnitTests
{
	public class ScriptItemUpdateTests
	{
		public static readonly object[][] ScriptItemTypes =
		{
			new object[] {"Show", true},
			new object[] {"Act", true},
			new object[] {"Scene",true},
			new object[] {"Synopsis", true},
			new object[] {"Dialogue", true},
			new object[] {"Action", true},
			new object[] {"Lighting", true},
			new object[] {"Sound", true},
			new object[] {"Staging", true},
			new object[] {"InitialStaging", true},
			new object[] {"Curtain", true},
			new object[] {"InitialCurtain", true},
			new object[] {"Comment", true},
			new object[] {"InvalidType", false }
			};
		[Theory, MemberData(nameof(ScriptItemTypes))]
		public void type(string type, bool expectedResult)
		{
			try
			{
				ScriptItemUpdate scriptItemUpdate = new ScriptItemUpdate(type);
				Assert.Equal(expectedResult, true);
			}
			catch (ArgumentException)
			{
				Assert.Equal(expectedResult, false);
			}

		}
	}
}