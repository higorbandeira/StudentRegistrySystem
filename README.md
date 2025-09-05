# StudentRegistrySystem
A robust and secure student registration system for elementary and high schools. It handles enrollment, age validation, legal guardianship, and communication, built with ASP.NET Core, PostgreSQL, and Docker.


Student Registry System
A comprehensive backend system for managing student registrations in elementary and high schools. It ensures compliance with age rules, legal guardianship, and provides real-time communication with guardians through a simulated notification system.

🚀 Features
Student Registration: Complete CRUD for student records with strict age validation based on the intended school year.

Guardian Management: Register up to two legal guardians per student with contact information.

Automated Notifications: Simulated notifications (WhatsApp, Email, SMS) for registration status (approved, pending, rejected).

Guardian Portal: A secure online portal for guardians to check registration status, view notifications, and update their contact details.

Data Compliance: Designed following LGPD (Brazilian GDPR) principles for data protection.

🛠️ Built With
Backend Framework: ASP.NET Core

Database: PostgreSQL with Entity Framework Core (EF Core)

Messaging Queue: RabbitMQ for handling notification queues

Containerization: Docker & Docker Compose

Architecture: Clean Architecture / Vertical Slice Architecture

📋 Prerequisites
Before you begin, ensure you have the following installed on your machine:

.NET 8.0 SDK

Docker Desktop (or equivalent engine)

Git

🏁 Getting Started
Follow these steps to get a local development environment running:

1. Clone the Repository
bash
git clone https://github.com/your-username/StudentRegistrySystem.git
cd StudentRegistrySystem
2. Configure Environment Variables
Create an .env file in the root directory (based on the provided .env.example)

bash
# Database
DB_HOST=localhost
DB_PORT=5432
DB_NAME=StudentRegistryDb
DB_USER=postgres
DB_PASSWORD=your_secure_password

# RabbitMQ
RABBITMQ_HOST=localhost
RABBITMQ_USER=guest
RABBITMQ_PASSWORD=guest
3. Start Dependencies with Docker Compose
This command will start PostgreSQL and RabbitMQ.

bash
docker-compose up -d
4. Run the Application
Apply the database migrations and run the API.

bash
# Navigate to the src/WebAPI project directory
cd src/StudentRegistrySystem.WebAPI

# Apply database migrations
dotnet ef database update

# Run the application
dotnet run
The API will be available at https://localhost:7000 (or http://localhost:5000).
The Guardian Portal frontend (if provided) will be available at a different port (e.g., http://localhost:3000).

🗄️ Database Schema
The main entities and their relationships are as follows:

Student: Contains student data (Name, BirthDate, SchoolYear, Status).

Guardian: Contains guardian information (Name, CPF, Contacts).

StudentGuardian: Junction table for the many-to-many relationship between Students and Guardians.

NotificationLog: Stores all notifications sent to guardians.

📡 API Endpoints (Examples)
Method	Endpoint	Description
POST	/api/students	Register a new student
GET	/api/students/{id}	Get a student by ID
GET	/api/guardians/{cpf}/students	(Portal) Get students by guardian's CPF
POST	/api/notifications/simulate	Simulate sending a notification
🧪 Testing
The solution includes Unit and Integration Tests using xUnit and Moq.

To run the tests:

bash
# From the solution root directory
dotnet test
📦 Project Structure
text
StudentRegistrySystem/
├── src/
│   ├── Application/         # Application layer (DTOs, Interfaces, Services)
│   ├── Domain/             # Domain layer (Entities, Enums, Exceptions)
│   ├── Infrastructure/     # Infrastructure layer (Persistence, Messaging)
│   └── WebAPI/             # Presentation layer (Controllers, Middleware)
├── tests/
│   ├── Application.Tests/  # Unit tests for Application layer
│   └── IntegrationTests/   # Integration tests
├── docker-compose.yml      # Docker compose for dependencies
└── README.md
👥 Contributing
Fork the Project
