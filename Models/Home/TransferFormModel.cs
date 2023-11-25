using Microsoft.AspNetCore.Mvc;

namespace ASP.Models.Home
{
	/// <summary>
	///Моделі форми мають автоматичний мапер, тобто зазначення полів (властивостей)
	///моделі заповнюються за забігом з іменами полів форм. Однак, часто в HTML прийнято вживати 
	///	kebab-casing (user-firstname), який не дозволений у C#.
	/// У такому разі мапінг зазначається атрибутами
	/// 
	/// FromQuery - з URL (get-параметри)
	/// FromForm - з тіла (post-параметри)
	/// </summary>
	public class TransferFormModel
	{
		[FromForm(Name = "user-firstname")]
		public String UserFirstName { get; set; } = null;
		[FromForm(Name = "user-lastname")]
		public String UserLastName { get; set; } = null;
	}
}
