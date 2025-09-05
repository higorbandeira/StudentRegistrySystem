# StudentRegistrySystem
A robust and secure student registration system for elementary and high schools. It handles enrollment, age validation, legal guardianship, and communication, built with ASP.NET Core, PostgreSQL, and Docker.
Student Registry System
A complete backend system for managing student registrations in elementary and high schools, featuring age validation, legal guardian management, and an integrated notification system using Kafka, with comprehensive observability through Datadog.

📋 Table of Contents
Overview

Features

Technology Stack

Monitoring & Observability

Architecture

Prerequisites

Quick Start

API Documentation

Testing

Deployment

Contributing

🎯 Overview
The Student Registry System is designed to streamline student enrollment processes while ensuring compliance with age requirements and legal guardianship rules. The system provides comprehensive observability through Datadog integration for monitoring, logging, and APM.

✨ Features
Core Functionality
Student Registration: Complete CRUD operations with age validation

Guardian Management: Support for up to two legal guardians per student

Age Validation: Automatic validation based on Brazilian education standards

Approval Workflow: Manual approval process for age exceptions

Notification System
Multi-channel notifications (WhatsApp, Email, SMS - simulated)

Real-time status updates

Notification history and tracking

Kafka-based message queue for reliability

Monitoring & Observability
Datadog APM: Distributed tracing and performance monitoring

Custom Metrics: Business metrics tracking for registrations and notifications

Log Management: Structured logging with Datadog integration

Real-time Dashboards: Operational and business metrics monitoring

🛠️ Technology Stack
Component	Technology
Backend Framework	ASP.NET Core 8.0
Database	PostgreSQL with Entity Framework Core
Message Broker	Apache Kafka
Monitoring	Datadog APM, Metrics, Logs
Containerization	Docker & Docker Compose
Testing	xUnit, Moq, TestContainers
Documentation	Swagger/OpenAPI
📊 Monitoring & Observability
Datadog Integration
The system is fully integrated with Datadog for comprehensive observability:

APM (Application Performance Monitoring)
Distributed Tracing: End-to-end request tracing across services

Performance Metrics: Response times, throughput, error rates

Service Map: Automatic dependency mapping

csharp
// Example of custom Datadog tracing
using Datadog.Trace;

public class StudentService
{
    public async Task<Student> RegisterStudent(StudentRegistrationDto dto)
    {
        using var scope = Tracer.Instance.StartActive("student.registration");
        scope.Span.SetTag("student.age", dto.Age);
        scope.Span.SetTag("school.year", dto.SchoolYear);
        
        // Business logic here
    }
}
Custom Metrics
Track business-specific metrics:

csharp
// Track registration metrics
DogStatsd.Increment("student.registrations.total");
DogStatsd.Increment("student.registrations.status.pending");
DogStatsd.Gauge("student.age", studentAge);
Log Management
Structured JSON logging with Datadog integration

Log correlation with traces

Custom log attributes for business context

Configuration
json
{
  "Datadog": {
    "Url": "https://app.datadoghq.com",
    "ApiKey": "${DD_API_KEY}",
    "ServiceName": "student-registry-system",
    "Environment": "production"
  }
}
Key Metrics Tracked
Metric Name	Type	Description
student.registrations.total	Counter	Total student registrations
student.registrations.status.pending	Counter	Pending approval registrations
student.age	Gauge	Age distribution of students
notification.sent.total	Counter	Total notifications sent
notification.delivery.status	Counter	Notification delivery status
api.response_time	Histogram	API endpoint response times
🏗️ Architecture
The system follows Clean Architecture principles with Datadog integration:

text
src/
├── Application/          # Application layer (Use Cases, DTOs, Interfaces)
├── Domain/              # Domain layer (Entities, Value Objects, Domain Services)
├── Infrastructure/      # Infrastructure (Persistence, Messaging, External Services)
├── WebAPI/              # Presentation layer (Controllers, Middleware, Datadog config)
└── Notifications.Consumer/ # Kafka consumer with Datadog tracing
Datadog Components
Datadog Agent: Running as Docker container

.NET Tracer: Automatic instrumentation

Custom Metrics: Business-level monitoring

Log Pipeline: Structured logging integration

📋 Prerequisites
Before installation, ensure you have:

Docker Desktop 20.10+ Download

.NET 8.0 SDK Download

Datadog Account Sign up

Datadog API Key from your account settings

Git Download

4GB+ RAM available for containers

🚀 Quick Start
1. Clone and Setup
bash
git clone https://github.com/higorbandeira/StudentRegistrySystem
cd student-registry-system
2. Environment Configuration
bash
# Copy and configure environment variables
cp .env.example .env
Edit the .env file with your configuration:

env
# Database
DB_HOST=localhost
DB_PORT=5432
DB_NAME=StudentRegistryDb
DB_USER=postgres
DB_PASSWORD=StrongPassword123!

# Kafka
KAFKA_BOOTSTRAP_SERVERS=localhost:9092
NOTIFICATIONS_TOPIC=student-notifications

# Datadog
DD_API_KEY=your_datadog_api_key_here
DD_SITE=datadoghq.com
DD_SERVICE=student-registry-system
DD_ENV=development
DD_APM_ENABLED=true
DD_LOGS_INJECTION=true
3. Start with Datadog
bash
# Start all services including Datadog agent
docker-compose --env-file .env up -d

# Apply database migrations
cd src/WebAPI
dotnet ef database update

# Run the application with Datadog tracing
DD_API_KEY=your_api_key_here dotnet run
4. Verify Datadog Integration
Check your Datadog dashboard for:

✅ Service appearing in APM services list

✅ Metrics being received

✅ Logs flowing to Datadog

✅ Infrastructure monitoring data

📊 Datadog Dashboard Setup
Import the pre-configured dashboard template:

Navigate to Dashboards → New Dashboard in Datadog

Select "Import Dashboard JSON"

Use the template from monitoring/datadog-dashboard.json

🧪 Testing with Datadog
Run tests with Datadog monitoring:

bash
# Run tests with Datadog integration
DD_API_KEY=your_api_key_here dotnet test --logger "trx;LogFileName=testresults.trx"
🚀 Deployment
Production Deployment with Datadog
yaml
# Example Kubernetes deployment with Datadog
apiVersion: apps/v1
kind: Deployment
metadata:
  name: student-registry-api
spec:
  template:
    spec:
      containers:
      - name: api
        image: student-registry-api:latest
        env:
        - name: DD_API_KEY
          valueFrom:
            secretKeyRef:
              name: datadog-secret
              key: api-key
        - name: DD_APM_ENABLED
          value: "true"
📈 Monitoring & Alerts
Set up Datadog monitors for:

High Error Rates: API error percentage > 5%

Slow Response Times: p95 response time > 500ms

Notification Failures: Failed notification rate > 10%

Database Performance: Slow queries detection

🤝 Contributing
When adding new features, ensure:

Add appropriate Datadog metrics and tracing

Update dashboard templates if needed

Include monitoring documentation

Test with Datadog integration enabled
