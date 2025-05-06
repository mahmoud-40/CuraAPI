# CuraAPI

CuraAPI is the backend service for the **Cura** Virtual Health Assistant, developed as part of **SalamHack 2025** by **Team Nexus**. It is built using **ASP.NET Core** and provides essential features such as user authentication, notifications, and communication with the AI model.

This API is responsible for handling secure user data, sending notifications, managing messaging to the AI model, and supporting medication reminders.


## Features

- **User Authentication**: Secure login, registration, and profile management using JWT.
- **Notifications**: Send and manage notifications for users about their health-related tasks (e.g., medication reminders).
- **Message Communication**: Send messages to the AI model for medical assistance or queries.
- **AI Integration**: The API interacts with the AI model (Cura.AiModel) for generating medical responses.


## API Endpoints

### Notification Endpoints

- **GET /api/Notification/{userId}**  
  Retrieves notifications for a specific user.  
  **Response:** JSON list of notifications.

- **DELETE /api/Notification/{userId}**  
  Deletes notifications for a specific user.  
  **Response:** Success or failure status.

- **PUT /api/Notification/{notificationId}**  
  Marks a specific notification as read.  
  **Response:** Success or failure status.

- **POST /api/Notification**  
  Sends a new notification to the system.  
  **Request Body:** Notification details (e.g., message, user).  
  **Response:** Success status.

### Message Endpoints

- **POST /api/Message/send**  
  Sends a message to the AI model for medical assistance or health-related inquiries.  
  **Request Body:**

  ```json
  {
    "userId": "12345",
    "message": "What is the dosage for Paracetamol?"
  }
  ```
  **Response:** JSON object containing the AI's response.


## Requirements

### Prerequisites

- **.NET 7** or later
- **SQL Server**
- **Entity Framework Core**

## How to Run

### 1. Setup the API (Cura.API)

1. Clone the repository:

   ```bash
   git clone https://github.com/mahmoud-40/CuraAPI.git
   cd CuraAPI
   ```

2. **Configure the Database**:  
   - Update the `appsettings.json` file with your **SQL Server** connection string.

3. **Install Dependencies**:  
   Run the following command to restore the required NuGet packages:

   ```bash
   dotnet restore
   ```

4. **Apply Database Migrations**:  
   Apply the migrations to set up the database schema.

   ```bash
   dotnet ef database update
   ```

5. **Run the API**:  
   Start the API on port 5164:

   ```bash
   dotnet run
   ```

   The API will be available at `http://localhost:5164`.


## Database

- The database is implemented using **SQL Server** and will be optimized for additional features (e.g., saving chat history, handling appointments).
- The **Entity Relationship Diagram (ERD)** for the database schema:
![ERD](https://github.com/user-attachments/assets/d48e7037-d689-4ad6-9281-2a8bfc4d8209)

## Future Enhancements

- **Chat History**: Saving chat history with the AI model for user reference.
- **Appointment Scheduling**: Integration with a scheduling system to book healthcare appointments.
- **AI Model Improvements**: Enhance the AI's capabilities for more accurate medical responses.


## Team Nexus

- **Mahmoud Abdulmawlaa** - Backend Engineer
- **Ahmed Waleed** - AI Engineer
- **Rana Mohy** - Flutter Developer
- **Menna Fathy** - UI/UX Developer
- **Shahd Gomma** - Business Developer

For more details, visit the main project repository: [Cura](https://github.com/mahmoud-40/Cura).
