using App.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Mvc.Controllers
{
    public class EventsController : Controller
    {
        // Bellekte saklanan örnek liste (uygulama boyunca geçerli olacak)
        private static List<EventModel> eventList = new()
        {
            new EventModel
            {
                Id = 1,
                Title = "Software Conference",
                Description = "Presentations about new technologies.",
                Date = DateTime.UtcNow.AddDays(7)
            },
            new EventModel
            {
                Id = 2,
                Title = "Hackathon 2025",
                Description = "24-hour coding competition.",
                Date = DateTime.UtcNow.AddMonths(1)
            }
        };

        // List all events
        public IActionResult List()
        {
            return View(eventList);
        }

        // Show details of a specific event
        public IActionResult Details(int id)
        {
            var evt = eventList.FirstOrDefault(e => e.Id == id);
            if (evt == null) return NotFound();
            return View(evt);
        }

        //Create new event (GET)
        public IActionResult Create()
        {
            return View();
        }

        // Create new event (POST)
        [HttpPost]
        public IActionResult Create(EventModel newEvent)
        {
            if (ModelState.IsValid)
            {
                newEvent.Id = eventList.Max(e => e.Id) + 1;
                eventList.Add(newEvent);
                return RedirectToAction("List");
            }
            return View(newEvent);
        }

        //Edit event (GET)
        public IActionResult Edit(int id)
        {
            var evt = eventList.FirstOrDefault(e => e.Id == id);
            if (evt == null) return NotFound();
            return View(evt);
        }

        //Edit event (POST)
        [HttpPost]
        public IActionResult Edit(EventModel updatedEvent)
        {
            var existing = eventList.FirstOrDefault(e => e.Id == updatedEvent.Id);
            if (existing == null) return NotFound();

            existing.Title = updatedEvent.Title;
            existing.Description = updatedEvent.Description;
            existing.Date = updatedEvent.Date;

            return RedirectToAction("List");
        }

        //Delete event
        public IActionResult Delete(int id)
        {
            var evt = eventList.FirstOrDefault(e => e.Id == id);
            if (evt != null)
            {
                eventList.Remove(evt);
            }
            return RedirectToAction("List");
        }
    }
}
