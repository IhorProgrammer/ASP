namespace ASP.Models.Home
{
	/// <summary>
	/// Модель з даними необхідними для відображення сторінки /Home/Transfer
	/// </summary>
	public record class TransferViewModel
	{
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
		public String ControllerName { get; set; } = null!;
		public TransferFormModel? FormModel { get; set; }

	}
}
