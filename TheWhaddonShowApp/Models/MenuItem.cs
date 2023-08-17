namespace TheWhaddonShowApp.Models
{
	public class MenuItem
	{
		public string Text { get; set; }

		public string? Icon { get; set; }

		public string? IconLabel { get; set; }

		public string Controller { get; set; }

		public string? Action { get; set; }

		public List<MenuItem>? SubItems { get; set; }

		public MenuItem(string text, string controller, string? action)
		{
			Text = text;
			Controller = controller;
			Action = action;
		}


		public MenuItem(string text, string controller, string? action, string? icon, List<MenuItem>? subItems = null)
		{
			Text = text;
			Controller = controller;
			Action = action;
			Icon = icon;
			SubItems = subItems;
		}

	}
}
