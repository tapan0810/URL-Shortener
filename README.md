🔗 URL Shortener – ASP.NET Core Web API + Frontend

A full-stack URL Shortener application built using ASP.NET Core Web API for the backend and HTML, CSS, and JavaScript for the frontend.

This project demonstrates clean architecture principles, RESTful API design, and structured layering with Controllers, Services, DTOs, and EF Core integration.

🚀 Features
🔗 URL Shortening

Convert long URLs into short, shareable links

Automatic short code generation

Persistent storage in database

🔁 Redirection

Short URL redirects to original long URL

Fast and reliable redirection handling

📊 Clean Backend Architecture

Controller → Service → Data → Database

DTO-based request/response models

Middleware support

Dependency Injection

🎨 Lightweight Frontend

Simple UI built using:

HTML

CSS

Vanilla JavaScript

API integration via Fetch/AJAX

User-friendly input and output display

🛠️ Tech Stack
Backend

ASP.NET Core Web API

Entity Framework Core

SQL Server

RESTful API Design

Dependency Injection

Frontend

HTML5

CSS3

JavaScript (Vanilla JS)

📂 Project Structure
URL-Shortener
│
├── URL_S_frontend
│   ├── index.html
│   ├── style.css
│   └── script.js
│
├── URL_Shortner_API
│   ├── Controllers
│   ├── DTOs
│   ├── Data
│   ├── Helpers
│   ├── Middleware
│   ├── Services
│   ├── Models
│   ├── Migrations
│   └── Program.cs
│
└── README.md
⚙️ How It Works

1️⃣ User enters a long URL in frontend
2️⃣ Frontend sends POST request to API
3️⃣ API generates unique short code
4️⃣ Short URL is stored in database
5️⃣ API returns shortened URL
6️⃣ When accessed → API redirects to original URL

🔐 Backend Responsibilities

Validate URL input

Generate unique short codes

Store mapping (ShortCode ↔ OriginalUrl)

Handle redirection

Return structured API responses

⚙️ Setup Instructions
1️⃣ Clone Repository
git clone https://github.com/your-username/URL-Shortener.git
cd URL-Shortener
2️⃣ Configure Database

Update appsettings.json in API project:

"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=UrlShortenerDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
3️⃣ Apply Migrations
dotnet ef database update

If no migrations exist:

dotnet ef migrations add InitialCreate
dotnet ef database update
4️⃣ Run Backend
dotnet run

Backend will run at:

https://localhost:xxxx
5️⃣ Run Frontend

Open:

URL_S_frontend/index.html

In browser.

🧠 Learning Highlights

This project demonstrates:

Clean separation of concerns

Service-based architecture

EF Core Code-First approach

REST API best practices

Frontend-Backend integration

Scalable backend structure

🔮 Future Improvements

Authentication & User Accounts

Click analytics tracking

Expiry-based links

Custom short URLs

Rate limiting

Docker containerization

Deployment on Azure / AWS

👨‍💻 Author

Developed as a structured full-stack backend learning project focusing on scalable API design and clean implementation.
