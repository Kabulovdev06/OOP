using System.Diagnostics.Tracing;
using dars_9.Models;

namespace dars_9.Service;

public class EventService
{
      private List<Event> events;

      public EventService()
      {
            events = new List<Event>();
      }

      public Event AddEvent(Event eventt)
      {
            eventt.Id = Guid.NewGuid();
            events.Add(eventt);

            return eventt;
      }

      public Event GetById(Guid eventId)
      {
            foreach (var eventt in events)
            {
                  if (eventt.Id == eventId)
                  {
                        return eventt;
                  }
            }

            return null;
      }

      public bool DeleteEvent(Guid eventId)

      {
            var eventFromDb = GetById(eventId);
            if (eventFromDb is null)
            {
                  return false;
            }

            events.Remove(eventFromDb);
            return true;
      }

      public bool UpdateEvent(Event eventt)
      {
            var eventFrom = GetById(eventt.Id);
            if (eventFrom is null)
            {
                  return false;
            }

            var index = events.IndexOf(eventFrom);
            events[index] = eventt;
            return true;
      }

      public List<Event> GetEventsByLocation(string location)
      {
            var sameLocation = new List<Event>();
            foreach (var eventa in events)
            {
                  if (eventa.Location == location)
                  {
                        sameLocation.Add(eventa);
                  }
            }

            return sameLocation;
      }

      public Event GetPopularEvent()
      {
            var newEvent = new Event();
            foreach (var eventa in events)
            {
                  if (newEvent.Attendees.Count < eventa.Attendees.Count)
                  {
                        newEvent = eventa;
                  }
            }

            return newEvent;
      }

      public Event GetMaxTaggEvent()
      {
            var newEvent = new Event();
            foreach (var eventa in events)
            {
                  if (eventa.Tags.Count < newEvent.Tags.Count)
                  {
                        newEvent = eventa;
                  }
            }

            return newEvent;
      }

      public bool AddPersonToEvent(Guid eventId, string name)
      {
            var eventFromDb = GetById(eventId);
            if (eventFromDb is null)
            {
                  return false;
            }

            events[events.IndexOf(eventFromDb)].Attendees.Add(name);
            return true;
      }

      public void DataSeed()
      {
            var names = new List<string>();
            names.Add("Azizbek");
            names.Add("Iskandar");
            names.Add("Abduazim");
            names.Add("Eldor");
            names.Add("Bexro'z");
            names.Add("Lazizbek");
            var tags = new List<string>();
            tags.Add("Dars o'tildi");
            tags.Add("Dars o'tildi");
            tags.Add("cofebreak");
            tags.Add("Dars tugadi");
            var events = new Event()
            {
                  Id = Guid.NewGuid(),
                  Title = "Yakshanba",
                  Location = "Sergeli",
                  Date = DateTime.Now,
                  Discription = "New Year",
                  Attendees = names,
                  Tags = tags,
            };
            AddEvent(events);
            var names2 = new List<string>();
            names2.Add("Aziz");
            names2.Add("Asad");
            names2.Add("Eldor");
            names2.Add("Eldor");
            names2.Add("Eldor");
            names2.Add("Husan");
            var tags2 = new List<string>();
            tags2.Add("Ovqatlandik");
            tags2.Add("Raqs Tushdik");
            tags2.Add("Urishdik");
            tags2.Add("bekorchilk");
            var eveent2 = new Event()
            {
                  Id = Guid.NewGuid(),
                  Title = "Var",
                  Location = "PDP",
                  Date = DateTime.Now,
                  Discription = "Fight of my friend",
                  Attendees = names2,
                  Tags = tags2
            };
            AddEvent(events);
      }
}