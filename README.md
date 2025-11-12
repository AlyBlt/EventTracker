# EventTracker

A simple **Event Tracking Application** built with **ASP.NET Core MVC**.  
This project demonstrates basic **CRUD (Create, Read, Update, Delete)** operations without using a database — all event data is stored in an in-memory list.

---

## 🎯 **Project Overview**
The goal of this project is to implement a simple event management system that allows users to:
- View a list of upcoming events
- Add new events
- Edit existing events
- View event details
- Delete events

---

## 🧠 **Technologies Used**
- ASP.NET Core MVC (.NET 8)
- C#
- Razor Views (CSHTML)
- Bootstrap (for basic styling)

---

## 🧩 **Project Structure**
```
EventTracker/
│
├── Controllers/
│   └── EventsController.cs
│
├── Models/
│   └── EventModel.cs
│
├── Views/
│   └── Events/
│       ├── List.cshtml
│       ├── Details.cshtml
│       ├── Create.cshtml
│       └── Edit.cshtml
│
└── Program.cs
```

---

## ⚙️ How to Run

1. Clone this repository:
   ```bash
   git clone https://github.com/AlyBlt/EventTracker.git
   ```
2. Run the project using the command:
   ```bash
   dotnet run
   ```
3. Open your browser and go to:  
👉 [https://localhost:7082](https://localhost:7082)

*Note: The port number may be different on your machine.*

---

## 👨‍💻 Author

Developed by **Aliye Bulut**  
🔗 [https://github.com/AlyBlt](https://github.com/AlyBlt)  

As part of *Backend course assignment-Task 9: Event Tracking Application*  
Built with **.NET 8**