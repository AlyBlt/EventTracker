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
    },
    new EventModel
    {
        Id = 10,
        Title = "Old Hackathon",
        Description = "Past coding competition.",
        Date = DateTime.UtcNow.AddDays(-15) // 15 gün önce
    },
    new EventModel
    {
        Id = 3,
        Title = "AI & Machine Learning Summit",
        Description = "Discussions on the latest trends in artificial intelligence and machine learning.",
        Date = DateTime.UtcNow.AddDays(20)
    },
    new EventModel
    {
        Id = 4,
        Title = "Cybersecurity Workshop",
        Description = "Hands-on workshop focusing on ethical hacking and data protection.",
        Date = DateTime.UtcNow.AddDays(35)
    },
    new EventModel
    {
        Id = 5,
        Title = "Cloud Computing Bootcamp",
        Description = "An intensive training camp on AWS, Azure, and Google Cloud fundamentals.",
        Date = DateTime.UtcNow.AddDays(50)
    },
    new EventModel
    {
        Id = 9,
        Title = "Tech Expo 2024",
        Description = "Exhibition showcasing latest tech products.",
        Date = DateTime.UtcNow.AddMonths(-2) // 2 ay önce
    },
    
    new EventModel
    {
        Id = 6,
        Title = "Startup Pitch Night",
        Description = "Local startups present their ideas to investors and mentors.",
        Date = DateTime.UtcNow.AddDays(60)
    },
    new EventModel
    {
        Id = 7,
        Title = "Web Development Meetup",
        Description = "Community meetup for frontend and backend developers.",
        Date = DateTime.UtcNow.AddDays(10)
    },

    new EventModel
    {
        Id = 8,
        Title = "Networking Event 2025",
        Description = "A meetup for professionals to network.",
        Date = DateTime.UtcNow.AddDays(-5) // 5 gün önce
    },
    
};

        // List action
        public IActionResult List(string? search, string? startDate, string? endDate)
        {
            var events = eventList.AsQueryable();

            // Text arama
            if (!string.IsNullOrEmpty(search))
            {
                events = events.Where(e =>
                    e.Title.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    e.Description.Contains(search, StringComparison.OrdinalIgnoreCase)
                );
            }

            // Date filtreleme
            if (DateTime.TryParse(startDate, out var start))
                events = events.Where(e => e.Date.Date >= start);

            if (DateTime.TryParse(endDate, out var end))
                events = events.Where(e => e.Date.Date <= end);

            ViewData["Search"] = search;
            ViewData["StartDate"] = startDate;
            ViewData["EndDate"] = endDate;

            return View(events.ToList());
        }


        // List all events
        //public IActionResult List()
        //{
        //    return View(eventList);
        //}

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
                TempData["SuccessMessage"] = "✅ Event created successfully!";
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

            TempData["SuccessMessage"] = "✏️ Event updated successfully!";
            return RedirectToAction("List");
        }

       
        // POST: actually delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var evt = eventList.FirstOrDefault(e => e.Id == id);
            if (evt != null)
            {
                eventList.Remove(evt);
                TempData["SuccessMessage"] = "🗑️ Event deleted successfully!";
            }
            return RedirectToAction("List");
        }
    }
}
