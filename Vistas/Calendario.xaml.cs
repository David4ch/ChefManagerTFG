using Plugin.Maui.Calendar.Models;

namespace ChefManager.Vistas;

public partial class Calendario : ContentPage
{
	public EventCollection Events { get; set; }
	public Calendario()
	{
		InitializeComponent();
        Events = new EventCollection{
            [DateTime.Now] = new List<EventModel>{
        new EventModel { Name = "Cool event1", Description = "This is Cool event1's description!" },
      }
        };
        BindingContext = this;    
    }


}

internal class EventModel
{
    public string Name { get; set; }
    public string Description { get; set; }
}